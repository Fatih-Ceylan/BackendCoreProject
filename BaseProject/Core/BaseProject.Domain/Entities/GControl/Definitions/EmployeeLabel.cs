using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GControl.Definitions
{
    public class EmployeeLabel : BaseEntity
    {
        public string Name { get; set; } 
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
    }
}
