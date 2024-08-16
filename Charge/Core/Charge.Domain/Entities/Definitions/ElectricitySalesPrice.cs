using Utilities.Core.UtilityDomain.Entities;

namespace GCharge.Domain.Entities.Definitions
{
    public class ElectricitySalesPrice : BaseEntity
    {
        public string Title { get; set; }
        public string? ChargePointId { get; set; }

        public decimal PricePerKWh { get; set; }
        public int VatRate { get; set; } = 20;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDefault { get; set; }
        public virtual ChargePoint? ChargePoint { get; set; }
    }
}
