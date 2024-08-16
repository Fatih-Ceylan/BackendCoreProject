using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.HumanResourcesManagement.EmployeeList
{
    public class EmployeeBranch : BaseEntity
    {
        public string BranchName { get; set; }
        public Employee Employee { get; set; }
    }
}
