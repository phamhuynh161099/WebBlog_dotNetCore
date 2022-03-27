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
    public class RoleInPermissionConfiguration : IEntityTypeConfiguration<RoleInPermission>
    {
        public void Configure(EntityTypeBuilder<RoleInPermission> builder)
        {
            builder.ToTable("RoleInPermissions");
            builder.HasKey(x => new { x.RoleId, x.PermissionId });
            builder.HasOne(x => x.Role).WithMany(x => x.RoleInPermissions).HasForeignKey(x => x.RoleId);
            builder.HasOne(x => x.Permission).WithMany(x => x.RoleInPermissions).HasForeignKey(x => x.PermissionId);
        }
    }
}