using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityApplication.VMs;

namespace GControl.Application.VMs.Definitions
{
    public class EmployeeNewBaseVM : BaseVM
    {
        public string Id { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime StartWorkDate { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool? isActive { get; set; }
        public bool? isDeleted { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; } 
        public string? CompanyId { get; set; }
        public EmployeeTypeVM EmployeeType { get; set; }
        public Company Company { get; set; }
        public LocationVM Location { get; set; }
        public BaseProject.Domain.Entities.Definitions.Department Department { get; set; }
        public ICollection<EmployeeLabelVM> EmployeeLabels { get; set; } 
        public ICollection<EmployeeFileVM> EmployeeFiles { get; set; }
        public ICollection<ShiftManagementVM> ShiftManagements { get; set; }
        public ICollection<ApplicationSettingVM> ApplicationSettings { get; set; }
    }
}
