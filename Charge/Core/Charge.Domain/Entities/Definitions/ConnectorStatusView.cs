namespace GCharge.Domain.Entities.Definitions
{
    public class ConnectorStatusView
    {
        public string ChargePointId { get; set; }
        public int ConnectorId { get; set; }
        public string? ConnectorName { get; set; }
        public string? LastStatus { get; set; }
        public DateTime? LastStatusTime { get; set; }
        public double? LastMeter { get; set; }
        public DateTime? LastMeterTime { get; set; }
        public int? TransactionId { get; set; }
        public string? StartTagId { get; set; }
        public DateTime? StartTime { get; set; }
        public double? MeterStart { get; set; }
        public string? StartResult { get; set; }
        public string? StopTagId { get; set; }
        public DateTime? StopTime { get; set; }
        public double? MeterStop { get; set; }
        public string? StopReason { get; set; }
    }
}
