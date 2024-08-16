using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.HumanResourcesManagement.EmployeeList
{
    public class EmployeeTitle : BaseEntity
    {
        public string TitleName { get; set; }
        public Employee Employee { get; set; }
    }
}
