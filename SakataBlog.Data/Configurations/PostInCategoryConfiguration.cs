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
    public class PostInCategoryConfiguration : IEntityTypeConfiguration<PostInCategory>
    {
        public void Configure(EntityTypeBuilder<PostInCategory> builder)
        {
            builder.ToTable("PostInCategories");
            builder.HasKey(x => new { x.CategoryId, x.PostId });
            builder.HasOne(x => x.Category).WithMany(x => x.PostInCategories).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Post).WithMany(x => x.PostInCategories).HasForeignKey(x => x.PostId);
        }
    }
}