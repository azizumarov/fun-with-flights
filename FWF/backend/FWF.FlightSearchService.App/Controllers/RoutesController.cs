using AutoMapper;
using FWF.Core.Domain.RepositoryInterfaces;
using FWF.Core.Domain.Results;
using FWF.Core.Helpers.QueryHelpers;
using FWF.FlightSearchService.App.Models;
using FWF.FlightSearchService.App.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FWF.FlightSearchService.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoutesController(IMapper mapper, ILogger<RoutesController> logger, IRouteRepository routeRepository) : ControllerBase
    {
        /// <summary>
        /// Get Route list
        /// </summary>
        /// <returns>RouteViewModel Collection</returns>
        [HttpGet]
        public async Task<ActionResult<PagedResult<List<RouteViewModel>>>> GetRoutesAsync(
            [FromQuery] RoutesClientRequest routesClientRequest)
        {
            if (routesClientRequest == null)
            {
                return BadRequest();
            }

            var pagingParameters = mapper.Map<PagingParameters>(routesClientRequest);
            var sortInfo = mapper.Map<SortInfo>(routesClientRequest);

            var totalCount = await routeRepository.GetCountAsync();
            var routes = await routeRepository.GetItemsAsync(pagingParameters, sortInfo);
            var result = routes.Select(route => mapper.Map<RouteViewModel>(route)).ToList();

            return Ok(new PagedResult<RouteViewModel>(result, totalCount));
        }
    }
}
