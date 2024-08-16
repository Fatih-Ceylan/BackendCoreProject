namespace GCharge.Application.VMs.Definitions
{
    public class ChargePointVM
    {
        public string ChargePointId { get; set; }

        public string? Name { get; set; }

        public string? Comment { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public List<ConnectorStatusVM>? ConnectorStatuses { get; set; }
    }
}
