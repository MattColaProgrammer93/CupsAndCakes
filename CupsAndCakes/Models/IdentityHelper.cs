using Microsoft.AspNetCore.Identity;

namespace CupsAndCakes.Models
{
#nullable disable
    public static class IdentityHelper
    {
        public const string Customer = "Customer";

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetService<RoleManager<IdentityRole>>();

            foreach(string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

        }

        public static async Task CreateDefaultUser(IServiceProvider provider, string role)
        {
            var userManager = provider.GetService<UserManager<IdentityUser>>();

            // If no user is present, make the default user
            int numUsers = (await userManager.GetUsersInRoleAsync(role)).Count;
            if (numUsers == 0)
            {
                var defaultUser = new IdentityUser()
                {
                    Email = "number1customer@cupandcakes.com",
                    UserName = "Number1"
                };

                await userManager.CreateAsync(defaultUser, "TheCoolGuy#1");

                await userManager.AddToRoleAsync(defaultUser, role);
            }
        }
    }
}
