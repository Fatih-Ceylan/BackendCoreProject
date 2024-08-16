using BaseProject.Domain.Entities.Definitions;
using BaseProject.Domain.Entities.GControl.Definitions.Files;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GControl.Definitions
{
    public class Employee : BaseEntity
    {
        public string? ProfilePicturePath { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime StartWorkDate { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool isActive { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? EmployeeTypeId { get; set; }
        public Guid? LocationId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? CompanyId { get; set; }
        public Branch Branch { get; set; }
        public Company Company { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public  Location Location { get; set; }
        public BaseProject.Domain.Entities.Definitions.Department Department { get; set; }
        public ICollection<EmployeeFile>? EmployeeFiles { get; set; }
        public ICollection<ShiftManagement> ShiftManagements { get; set; } = new List<ShiftManagement>();
        public ICollection<ApplicationSetting> ApplicationSettings { get; set; } = new List<ApplicationSetting>();
        public ICollection<EmployeeLabel> EmployeeLabels { get; set; } = new List<EmployeeLabel>();
    }
}
