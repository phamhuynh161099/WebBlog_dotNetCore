using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SakataBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Data.Configurations
{
    public class UserInRoleConfiguration : IEntityTypeConfiguration<UserInRole>
    {
        public void Configure(EntityTypeBuilder<UserInRole> builder)
        {
            builder.ToTable("UserInRoles");
            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.HasOne(x => x.User).WithMany(x => x.UserInRoles).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Role).WithMany(x => x.UserInRoles).HasForeignKey(x => x.RoleId);
        }
    }
}