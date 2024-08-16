using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GControl.Definitions
{
    public class Department : BaseEntity
    {
        public Guid BaseDepartmentId { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        public bool? isActive { get; set; }
        public BaseProject.Domain.Entities.Definitions.Department BaseDepartment { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
    }
}
