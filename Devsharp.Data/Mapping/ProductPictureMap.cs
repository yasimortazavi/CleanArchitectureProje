using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Devsharp.Core.Domian;

namespace Devsharp.Data.Mapping
{
    public class ProductPictureMap : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.HasKey(p => new { p.ProductId, p.PictureId });
        }
    }
}
