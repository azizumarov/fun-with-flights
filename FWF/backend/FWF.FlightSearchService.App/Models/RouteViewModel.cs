namespace FWF.FlightSearchService.App.Models
{
    public class RouteViewModel
    {
        public string Airline { get; set; }

        public string SourceAirport { get; set; }

        public string DestinationAirport { get; set; }

        public string CodeShare { get; set; }

        public int Stops { get; set; }

        public string Equipment { get; set; }

        public string SourceName { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
