using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityApplication.VMs;

namespace GControl.Application.VMs.Definitions
{
    public class LocationVM : BaseVM
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public int Radius { get; set; }
        public DateTime EntryTimeLimit { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LocationOut { get; set; }
        public bool IsEntryTimeLimitEnabled { get; set; }
        public string Description { get; set; }
        public string? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
