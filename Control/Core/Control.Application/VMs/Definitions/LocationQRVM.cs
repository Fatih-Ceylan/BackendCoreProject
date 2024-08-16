namespace GControl.Application.VMs.Definitions
{
    public class LocationQRVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Radius { get; set; }
        public DateTime EntryTimeLimit { get; set; }
        public bool IsEntryTimeLimitEnabled { get; set; }
    }
}
