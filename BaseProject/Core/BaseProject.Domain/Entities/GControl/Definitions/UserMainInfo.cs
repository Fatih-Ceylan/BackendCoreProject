using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GControl.Definitions
{
    public class UserMainInfo : BaseEntity 
    {
        public Guid AppUserId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
