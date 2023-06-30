using iShopping.Entities;
using Microsoft.AspNetCore.Identity;

namespace iShopping.Api.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(
                    options =>
                    {
                        options.Password.RequireNonAlphanumeric = true;
                        options.User.RequireUniqueEmail = true;
                        options.SignIn.RequireConfirmedEmail = true;
                    }
                )
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                ;

            return services;
        }
    }
}
