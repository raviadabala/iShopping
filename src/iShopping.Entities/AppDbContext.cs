using iShopping.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iShopping.Entities
{
    public class AppDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserEntityConfiguration());
            builder.ApplyConfiguration(new RoleEntityConfiguration());

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            User user = new User()
            {
                Id = 1,
                UserName = "Admin",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            builder.Entity<User>().HasData(user);

            var roles = new Role[] { 
                            new Role() { Id = 1, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                            new Role() { Id = 2, Name = "HR", ConcurrencyStamp = "2", NormalizedName = "Human Resource" } 
                        };

            builder.Entity<Role>().HasData(roles);


            foreach (Role role in roles)
            {
                builder.Entity<UserRole>().HasData(
                  new UserRole() { RoleId = role.Id, UserId = 1 }
                  );
            }

        }
    }
}