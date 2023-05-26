using iShopping.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, string adminPassword)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

        // Create a default admin user if it doesn't exist
        if (await userManager.FindByNameAsync("admin") == null)
        {
            var adminUser = new User
            {
                UserName = "admin",
                Email = "admin@example.com"
                // Set any additional properties for the user
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);

            if (result.Succeeded)
            {
                // Assign the "Admin" role to the admin user
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
            else
            {
                // Handle the error case if user creation fails
            }
        }
    }
}