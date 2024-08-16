namespace GCharge.Domain.Entities.Definitions
{
    public class ConnectorStatus
    {
        public string ChargePointId { get; set; }
        public int ConnectorId { get; set; }

        public string? ConnectorName { get; set; }

        public string? LastStatus { get; set; }
        public DateTime? LastStatusTime { get; set; }

        public double? LastMeter { get; set; }
        public DateTime? LastMeterTime { get; set; }
    }
}
