using BaseProject.Domain.Entities.Identity;
using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities
{
    public class B_BaseEntity : BaseEntity
    {
        public AppUser? CreatedByUser { get; set; }

        public AppUser? UpdatedByUser { get; set; }

        public AppUser? DeletedByUser { get; set; }
    }
}
