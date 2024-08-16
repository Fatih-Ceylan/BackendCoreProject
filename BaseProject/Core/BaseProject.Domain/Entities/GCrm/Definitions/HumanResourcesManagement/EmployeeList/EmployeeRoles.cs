using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.HumanResourcesManagement.EmployeeList
{
    public class EmployeeRoles : BaseEntity
    {
        public string Name { get; set; }
        public Employee Employee { get; set; }
    }
}
