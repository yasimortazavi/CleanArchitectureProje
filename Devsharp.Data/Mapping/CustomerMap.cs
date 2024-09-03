using Devsharp.Core.Domian;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devsharp.Data.Mapping
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
            //////////////////////////******************/////////////////////////////
            builder.Property(p => p.CreateDate).ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
            builder.HasComment("این جدول جهت مدیریت اطلاعات مشتریان است");
            builder.HasMany(p => p.ShoppingCartItems).WithOne(p => p.Customer).OnDelete(DeleteBehavior.Cascade).HasForeignKey(p=>p.CustomerID);
            builder.Property(p => p.Timestamp).IsRowVersion();
            builder.Property(p => p.FirstName).IsConcurrencyToken();
            builder.HasIndex(p => new { p.FirstName, p.LastName});


            builder.HasData(new Customer()
            {
                ID = 1,
                FirstName = "Test",
                LastName = "Test",
                UserName = "Test",  
                Password = "Test",
                EditDate = DateTime.Now

            }) ;

        }
    }
}
