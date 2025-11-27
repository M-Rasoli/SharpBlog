using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.AuthorAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.EfCore.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.UserName).IsRequired().HasMaxLength(240);
            builder.Property(a => a.Password).IsRequired().HasMaxLength(240);

            builder.HasMany(a => a.Categories).WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.Posts).WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Author>()
            {
                new Author() { Id = 1, UserName = "mmd", Password = "123" ,CreatedAt = new DateTime(2024,10,10,12,12,12,DateTimeKind.Local)}
            });
        }
    }
}
