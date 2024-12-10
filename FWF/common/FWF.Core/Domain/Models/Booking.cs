using FWF.Core.Domain.Interfaces;

namespace FWF.Core.Domain.Models
{
    public class Booking:IDomainClass
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
