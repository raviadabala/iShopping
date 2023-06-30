using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Entities;

public class User : IdentityUser<int>
{
    public string KnownAs { get; set; } = default!;
    public ICollection<UserRole> UserRoles { get; set; } = default!;
}

public class UserEntityConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(x=>x.UserRoles).WithOne(x=>x.User).HasForeignKey(x=>x.UserId).IsRequired();
        builder.HasKey(x => x.Id);
    }
}
