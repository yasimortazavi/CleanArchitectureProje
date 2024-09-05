using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Devsharp.Core.Domian;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Ignore(p => p.OrderStatus);

        }
    }
}
