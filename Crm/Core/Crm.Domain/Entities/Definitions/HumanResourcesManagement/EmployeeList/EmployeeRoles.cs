using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.HumanResourcesManagement.EmployeeList
{
    public class EmployeeRoles : BaseEntity
    {
        public string Name { get; set; }
        public Employee  Employee { get; set; }
    }
}
