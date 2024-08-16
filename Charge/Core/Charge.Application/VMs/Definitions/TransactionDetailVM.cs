namespace GCharge.Application.VMs.Definitions
{
    public class TransactionDetailVM
    {
        public string Id { get; set; }
        public int TransactionId { get; set; }
        public string ChargePointId { get; set; }
        public int ConnectorId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public double CurrentChargeKW { get; set; }
        public double MeterKWH { get; set; }
        public double StateOfCharge { get; set; }
    }
}
