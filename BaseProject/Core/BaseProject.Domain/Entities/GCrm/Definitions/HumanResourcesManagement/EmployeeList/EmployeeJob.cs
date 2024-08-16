using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.HumanResourcesManagement.EmployeeList
{
    public class EmployeeJob : BaseEntity
    {
        public string JobName { get; set; }
        public Employee Employee { get; set; }
    }
}
