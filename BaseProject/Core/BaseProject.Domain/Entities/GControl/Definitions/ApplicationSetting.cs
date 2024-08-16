using BaseProject.Domain.Entities.Definitions;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GControl.Definitions
{
    public class ApplicationSetting : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAccepted { get; set; }
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
