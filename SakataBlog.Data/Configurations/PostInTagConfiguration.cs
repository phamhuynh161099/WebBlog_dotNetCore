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
    public class PostInTagConfiguration : IEntityTypeConfiguration<PostInTag>
    {
        public void Configure(EntityTypeBuilder<PostInTag> builder)
        {
            builder.ToTable("PostInTags");
            builder.HasKey(x => new { x.PostId, x.TagId });
            builder.HasOne(x => x.Tag).WithMany(x => x.PostInTags).HasForeignKey(x => x.TagId);
            builder.HasOne(x => x.Post).WithMany(x => x.PostInTags).HasForeignKey(x => x.PostId);
        }
    }
}