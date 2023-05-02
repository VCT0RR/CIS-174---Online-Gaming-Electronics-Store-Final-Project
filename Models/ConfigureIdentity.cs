using Microsoft.AspNetCore.Identity;

namespace FinalProjectRyan.Models
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(
        IServiceProvider provider)
        {
            var roleManager =
                provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager =
                provider.GetRequiredService<UserManager<AdminUser>>();

            string username = "admin";
            string password = "blu";
            string roleName = "Admin";

            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            if (await userManager.FindByNameAsync(username) == null)
            {
                AdminUser user = new AdminUser { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
