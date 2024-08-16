using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.UserManagement
{
    public  class UserBranch : BaseEntity
    {
        public string  BranchName { get; set; }
        public Users  Users { get; set; }
    }
}
