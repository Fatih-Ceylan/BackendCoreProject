using Utilities.Core.UtilityDomain.Entities;

namespace BaseProject.Domain.Entities.GCrm.Definitions.UserManagement.Users
{
    public class UserTitle : BaseEntity
    {
        public string TitleName { get; set; }
        public Users Users { get; set; }
    }
}
