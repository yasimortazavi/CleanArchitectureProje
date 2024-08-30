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
            /// Ignore
            builder.Ignore(p => p.FirstName);
            builder.Property(p => p.ID).IsRequired().UseIdentityColumn(1, 1);
            ///key
            builder.HasKey("ID");
            //builder.Property(p => p.CreateDate).ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
            /// Conflit Version
            builder.Property(p => p.TimeStamp).IsRowVersion();

            builder.HasComment("جدول مشتریان");
            // کلید دوم درواقع کلید نیست اما مقدار آن یکتا است
            builder.HasAlternateKey("NationalCode");

            builder.Property(p => p.LastName).HasConversion(p => p.ToString(), p => "dear " + p);
            //builder.Property(p => p.Password).HasMaxLength(12);
            //builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired(true).HasDefaultValue("sasan");
             
            builder.Property(p => p.TimeStamp).IsRowVersion();
            builder.HasIndex(p => new { p.FirstName,p.LastName});


           

        }
    }
}
