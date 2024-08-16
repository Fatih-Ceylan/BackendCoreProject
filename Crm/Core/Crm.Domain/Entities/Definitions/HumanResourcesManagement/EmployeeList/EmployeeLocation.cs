using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.HumanResourcesManagement.EmployeeList
{
    public class EmployeeLocation : BaseEntity
    {
        public string LocationName { get; set; }
        public Employee  Employee { get; set; }
    }
}
