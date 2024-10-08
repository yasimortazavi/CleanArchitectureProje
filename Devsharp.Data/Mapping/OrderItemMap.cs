﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Devsharp.Core.Domian;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Mapping
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(p => new { p.ProductID, p.OrderID });
        }
    }
}
