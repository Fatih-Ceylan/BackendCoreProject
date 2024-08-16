using GCharge.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace GCharge.Persistence.Services.Identity
{
    public static class UserRoleService
    {

        public static async Task InitializeAsync(IServiceProvider serviceProvider, UserManager<AppUser> userManager)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();

            string[] roleNames = { "Admin", "MobileUser" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new AppRole { Name = roleName });
                }
            }

            var id = Guid.NewGuid().ToString();

            var adminUser = new AppUser
            {
                Id = id,
                FullName = "Admin User",
                UserName = "admin@admin",
                Email = "admin@admin"
            };

            var user = await userManager.FindByEmailAsync(adminUser.Email);

            if (user == null)
            {
                var createAdmin = await userManager.CreateAsync(adminUser, "admin");
                if (createAdmin.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
