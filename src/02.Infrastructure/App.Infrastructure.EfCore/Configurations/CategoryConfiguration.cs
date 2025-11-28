using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CategoryAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EfCore.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title).IsRequired().HasMaxLength(240);

            builder.HasMany(c => c.Posts).WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
