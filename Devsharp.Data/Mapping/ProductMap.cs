using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Devsharp.Core.Domian;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           // builder.HasMany(p => p.productCategories).WithOne(p => p.Product).HasForeignKey("ProductId");
        }
    }
}
