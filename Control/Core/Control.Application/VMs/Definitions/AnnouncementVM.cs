using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityApplication.VMs;

namespace GControl.Application.VMs.Definitions
{
    public class AnnouncementVM : BaseVM
    {
        public Company Company { get; set; }
        public ICollection<EmployeeLabelVM> EmployeeLabels { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int EmployeeCount { get; set; }
        public int EmployeeDepartmentCount { get; set; }
        public int SentToEmployeeCount { get; set; }
    }
}
