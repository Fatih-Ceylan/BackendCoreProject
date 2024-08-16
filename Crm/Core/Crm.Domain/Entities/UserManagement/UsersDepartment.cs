using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.UserManagement
{
    public  class UsersDepartment : BaseEntity
    {
        public string DepartmentName { get; set; }     
        public Users  Users { get; set; }
    }
}
