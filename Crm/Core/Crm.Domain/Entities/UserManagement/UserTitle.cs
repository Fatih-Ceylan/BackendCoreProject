using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.UserManagement
{
    public class UserTitle : BaseEntity
    {
        public string TitleName { get; set; }       
        public Users  Users { get; set; }
    }
}
