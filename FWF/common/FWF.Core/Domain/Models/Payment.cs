using FWF.Core.Domain.Interfaces;

namespace FWF.Core.Domain.Models
{
    public class Payment:IDomainClass
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }
    }
}
