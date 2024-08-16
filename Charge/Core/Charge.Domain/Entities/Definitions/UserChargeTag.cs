using GCharge.Domain.Entities.Identity;
using Utilities.Core.UtilityDomain.Entities;

namespace GCharge.Domain.Entities.Definitions
{
    public class UserChargeTag: BaseEntity
    {
        public string UserId { get; set; }
        
        public string TagId { get; set; }

        public AppUser User { get; set; }

        public ChargeTag Tag { get; set; }
    }
}
