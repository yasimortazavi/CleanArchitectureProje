using Microsoft.EntityFrameworkCore;
using Devsharp.Core.Domian;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
       

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(p => p.Children).WithOne(p => p.ParentCategory).HasForeignKey(p => p.ParentId).
                            OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Category()
            {
                ID = 1,
                CreateOn = DateTime.Now,
                UpdateOn = DateTime.Now,
                Name = "اصلی",
                ParentId = 1
            });

        }
    }
}
