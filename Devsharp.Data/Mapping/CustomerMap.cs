using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Devsharp.Core.Domian;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            
            ///key
            builder.HasKey("ID");
            // Conflit Version
            builder.Property(p => p.Timestamp).IsRowVersion();

           
            // کلید دوم درواقع کلید نیست اما مقدار آن یکتا است
            //builder.HasAlternateKey("NationalCode");

            builder.Property(p => p.LastName).HasConversion(p => p.ToString(), p => "dear " + p);
            

           

        }
    }
}
