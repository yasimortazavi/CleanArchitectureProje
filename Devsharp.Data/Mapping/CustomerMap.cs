using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {



            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();

        }
    }
}
