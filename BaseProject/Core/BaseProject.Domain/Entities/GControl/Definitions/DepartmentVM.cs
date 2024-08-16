using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GControl.Definitions
{
    public class DepartmentVM : BaseEntity
    {
        public string Name { get; set; }
        public string? BaseDepartmentId { get; set; }
    }
}
