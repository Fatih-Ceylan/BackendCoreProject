using GCharge.Domain.Entities.Identity;
using Utilities.Core.UtilityDomain.Entities;

namespace GCharge.Domain.Entities.Definitions
{
    public class UserTransaction : BaseEntity
    {
        public string? UserId { get; set; }
        public int TransactionId { get; set; }
        public string ChargePointId { get; set; }
        public decimal ElectricityLoadedKWh { get; set; }
        public decimal PricePerKWh { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal VatRate { get; set; } = 0.20m;
        public decimal GrandTotal { get; set; }

        public AppUser? User { get; set; }
    }
}
