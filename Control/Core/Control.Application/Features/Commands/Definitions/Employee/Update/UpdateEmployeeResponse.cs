using GControl.Application.VMs.Definitions;

namespace GControl.Application.Features.Commands.Definitions.Employee.Update
{
    public class UpdateEmployeeResponse
    {
        public string Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartWorkDate { get; set; }
        public string Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? EmployeeTypeId { get; set; }
        public string DepartmentId { get; set; }
        public bool isActive { get; set; }
        public string? ProfilePicturePath { get; set; }
        public string CompanyId { get; set; } 
        public List<EmployeeLabelVM> EmployeeLabelsId { get; set; }
        public List<ShiftManagementVM> ShiftManagementsId { get; set; }
        public List<ApplicationSettingVM> ApplicationSettingsId { get; set; }
        public string Message { get; set; }
    }
}
