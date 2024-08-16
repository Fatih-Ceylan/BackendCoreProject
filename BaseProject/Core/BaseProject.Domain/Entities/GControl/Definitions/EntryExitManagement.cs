using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GControl.Definitions
{
    public class EntryExitManagement : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid LocationId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsLocationOut { get; set; }
        public bool IsRegistrationType { get; set; }
        public string? Description { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? CompanyId { get; set; }
        public Branch Branch { get; set; }
        public Company Company { get; set; }
        public Location Location { get; set; }
        public Employee Employee { get; set; }

    }
}
