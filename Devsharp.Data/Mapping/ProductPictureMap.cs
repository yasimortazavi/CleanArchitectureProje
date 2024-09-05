using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Devsharp.Core.Domian;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Mapping
{
    public class ProductPictureMap : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.HasKey(p => new { p.ProductID, p.PictureID });
        }
    }
}
