using Microsoft.EntityFrameworkCore;
using SakataBlog.Data.Configurations;
using SakataBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakataBlog.Data.EF
{
    public class SakataBlogDbContext : DbContext
    {
        public SakataBlogDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Goi cac file configuration cua entity
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new PostInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PostInTagConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleInPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserInRoleConfiguration());
        }

        public DbSet<AppConfig> Configs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostInCategory> PostInCategories { get; set; }
        public DbSet<PostInTag> PostInTags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleInPermission> RoleInPermissions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
    }
}