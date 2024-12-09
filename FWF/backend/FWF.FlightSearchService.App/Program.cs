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
            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = options.DefaultPolicy;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    policy.WithOrigins("https://mobile.fwf.com", "https://web.fwf.com", "https://localhost:7090") // Allowed origins
                          .AllowAnyHeader()    // Allow all headers
                          .AllowAnyMethod();   // Allow all HTTP methods (GET, POST, etc.)
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Flight Search Service API",
                        Version = "v1"
                    });

                    // Configure Swagger to use Azure AD Authentication
                    c.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.OpenIdConnect,
                        OpenIdConnectUrl = new Uri($"https://login.microsoftonline.com/{builder.Configuration["AzureAd:TenantId"]}/v2.0/.well-known/openid-configuration"),
                        Description = "OIDC Authentication with Azure AD",
                        Flows = new Microsoft.OpenApi.Models.OpenApiOAuthFlows
                        {
                            AuthorizationCode = new Microsoft.OpenApi.Models.OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri($"https://login.microsoftonline.com/{builder.Configuration["AzureAd:TenantId"]}/oauth2/v2.0/authorize"),
                                TokenUrl = new Uri($"https://login.microsoftonline.com/{builder.Configuration["AzureAd:TenantId"]}/oauth2/v2.0/token"),
                                Scopes = new Dictionary<string, string>
                                {
                                    { "openid", "OpenID Connect" },
                                    { "profile", "User profile" },
                                    { "email", "User email" }
                                }
                            }
                        }
                    });

                    // Apply the security definition globally to all endpoints
                    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                    {
                        {
                            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                            {
                                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                                {
                                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                    Id = "oauth2"
                                }
                            },
                            new[] { "openid", "profile", "email" }
                        }
                    });
                });

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
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");

                    // Configure Swagger UI to integrate with Azure AD
                    c.OAuthClientId(builder.Configuration["AzureAd:ClientId"]);
                    c.OAuthUsePkce(); // PKCE is required for authorization code flow
                    c.OAuthAppName("Flight Search Service API");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("AllowSpecificOrigins");

            app.MapControllers()
                .RequireAuthorization("RequireAuthenticatedUser");

            app.Run();
        }
    }
}
