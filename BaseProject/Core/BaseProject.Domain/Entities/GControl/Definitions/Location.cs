using BaseProject.Domain.Entities.Definitions;
using BaseProject.Domain.Entities.GControl.Enums;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GControl.Definitions
{
    public class Location : BaseEntity
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public int Radius { get; set; }
        public DateTime EntryTimeLimit { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool IsEntryTimeLimitEnabled { get; set; }
        public LocationOutEnum LocationOut { get; set; }
        public string Description { get; set; }
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
