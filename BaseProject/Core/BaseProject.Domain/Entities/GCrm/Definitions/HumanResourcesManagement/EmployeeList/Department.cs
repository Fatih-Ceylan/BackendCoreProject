using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.HumanResourcesManagement.EmployeeList
{
    public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }
        public Employee Employee { get; set; }
    }
}
