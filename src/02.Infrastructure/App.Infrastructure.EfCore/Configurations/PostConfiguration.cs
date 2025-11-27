using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.PostAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EfCore.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).IsRequired().HasMaxLength(240);
            builder.Property(p => p.Text).IsRequired().HasMaxLength(4000);
            builder.Property(p => p.ImgUrl).IsRequired(false).HasMaxLength(4000);

        }
    }
}
