using AutoMapper;
using FWF.Core.Configurations;
using FWF.Core.Domain.RepositoryInterfaces;
using FWF.Dal.Models;
using FWF.Dal.Repositories;
using FWF.Dal.SqlContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FWF.Dal.Configuration
{
    public static class DalConfiguration
    {
        public static void ConfigureMappings(IMapperConfigurationExpression config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            config.CreateMap<Route, Core.Domain.Models.Route>().ReverseMap();
        }

        public static IServiceCollection ConfigureDal(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration[Constants.DATABASE_CONNECTION_STRING] ?? configuration.GetConnectionString(Constants.DATABASE_CONNECTION_STRING) ?? throw new Exception("Connection string not provided");

            services.AddDbContext<FwfDbContext>(options =>
            {
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("FWF.Dal"));
            });

            var dbFactory = new FwfContextFactory(connectionString);
            services.AddSingleton(typeof(IFwfContextFactory), dbFactory);

            services.AddTransient<IRouteRepository, RouteRepository>();

            return services;
        }
    }
}
