using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityApplication.VMs;

namespace GControl.Application.VMs.Definitions
{
    public class EmployeeVM : BaseVM
    {

        public string Id { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime StartWorkDate { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool? isActive { get; set; }
        public bool? isDeleted { get; set; }
        public string DepartmentId { get; set; }
        public string? UserType { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeTypeId { get; set; }
        //public string EmployeeTypeName { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? BranchId { get; set; }
        public string? BranchName { get; set; }
        public EmployeeTypeVM EmployeeType { get; set; }
        public Branch Branch{ get; set; }
        public Company Company { get; set; }
        public LocationVM Location { get; set; }
        public BaseProject.Domain.Entities.Definitions.Department Department { get; set; }
        public ICollection<EmployeeLabelVM> EmployeeLabelVMs { get; set; }
        public ICollection<EmployeeFileVM> EmployeeFiles { get; set; }
        public ICollection<ShiftManagementVM> ShiftManagementVMs { get; set; }
        public ICollection<ApplicationSettingVM> ApplicationSettingVMs { get; set; }
    }
}
