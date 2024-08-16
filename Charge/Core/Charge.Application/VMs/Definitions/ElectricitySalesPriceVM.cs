namespace GCharge.Application.VMs.Definitions
{
    public class ElectricitySalesPriceVM
    {
        public string Id { get; set; }
        public string? ChargePointId { get; set; }
        public string? ChargePointName { get; set; }
        public string Title { get; set; }
        public decimal PricePerKWh { get; set; }

        public int VatRate { get; set; } 
        //public string? Currency { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDefault { get; set; }
    }
}
