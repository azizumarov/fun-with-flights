using AutoMapper;
using Azure.Identity;
using FWF.Dal.Configuration;
using FWF.FlightSearchService.App.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using Microsoft.OpenApi.Models;

namespace FWF.FlightSearchService.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

            try
            {
                builder.Configuration.AddAzureKeyVault(
                new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
                new DefaultAzureCredential());
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex, "Error on adding secrets");
            }

            var configuration = builder.Configuration;

            builder.Services.ConfigureDal(configuration);

            // Add services to the container.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

            // Add Authorization
            builder.Services.AddAuthorization();
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            var config = new MapperConfiguration(cfg =>
            {
                FlightSearchServiceConfiguration.ConfigureMappings(cfg);
                DalConfiguration.ConfigureMappings(cfg);
            });

            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
