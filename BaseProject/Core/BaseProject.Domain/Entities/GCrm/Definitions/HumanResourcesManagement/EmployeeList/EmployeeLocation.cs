using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.HumanResourcesManagement.EmployeeList
{
    public class EmployeeLocation : BaseEntity
    {
        public string LocationName { get; set; }
        public Employee Employee { get; set; }
    }
}
