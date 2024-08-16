using Microsoft.AspNetCore.Identity;

namespace GCharge.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public AppRole() : base()
        {
            Id = Guid.NewGuid().ToString(); 
        }

        public AppRole(string roleName) : base(roleName)
        {
            Id = Guid.NewGuid().ToString();
        }
    }

}
