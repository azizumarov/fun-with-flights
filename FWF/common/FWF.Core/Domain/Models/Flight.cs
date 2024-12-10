using FWF.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWF.Core.Domain.Models
{
    public class Flight:IDomainClass
    {
        public Guid Id { get; set; }
        public string Airline { get; set; }
        public string SourceAirport { get; set; }
        public string DestinationAirport { get; set; }
        public bool CodeShare { get; set; }
        public int Stops { get; set; }
        public string? Equipment { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
    }
}
