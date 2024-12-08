using FWF.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FWF.FlightSearchService.App.Requests
{
    public class PagedClientRequest
    {
        [FromQuery]
        public int Skip { get; set; } = 0;

        [FromQuery]
        public int Take { get; set; } = 100;

        [FromQuery]
        public string SortBy { get; set; }

        [FromQuery]
        public SortDirection Direction { get; set; }
    }
}
