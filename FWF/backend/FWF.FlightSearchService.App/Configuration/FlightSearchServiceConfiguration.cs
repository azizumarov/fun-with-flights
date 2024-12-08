using AutoMapper;
using FWF.Core.Helpers.QueryHelpers;
using FWF.FlightSearchService.App.Models;
using FWF.FlightSearchService.App.Requests;

namespace FWF.FlightSearchService.App.Configuration
{
    public static class FlightSearchServiceConfiguration
    {
        public static void ConfigureMappings(IMapperConfigurationExpression config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            config.CreateMap<PagedClientRequest, PagingParameters>().ReverseMap();
            config.CreateMap<PagedClientRequest, SortInfo>().ReverseMap();
            config.CreateMap<RouteViewModel, Core.Domain.Models.Route>().ReverseMap();

        }
    }
}
