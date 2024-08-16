using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GControl.Definitions
{
    public class Announcement : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<EmployeeLabel> EmployeeLabels { get; set; } = new List<EmployeeLabel>();
        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
