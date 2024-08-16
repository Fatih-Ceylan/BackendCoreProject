using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.Identity
{
    public class AppUserAppellation : BaseEntity
    {
        public string Name { get; set; }

        public Guid? MainAppellationId { get; set; }

        public Guid? CompanyId { get; set; }

        public Guid? BranchId { get; set; }
    }
}
