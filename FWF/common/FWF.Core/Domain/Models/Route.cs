using FWF.Core.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FWF.Core.Domain.Models
{
    public class Route:IDomainClass
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
