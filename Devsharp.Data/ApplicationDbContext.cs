using Microsoft.EntityFrameworkCore;
using Devsharp.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devsharp.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=.; initial Catalog=ShopCleanArhitector;integrated security = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Entity = modelBuilder.Model.GetEntityTypes();
            foreach (var entityType in Entity) 
            {
                var property = entityType.FindProperty("CreateOn");
                if (property != null)
                {
                    property.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
                    property.SetDefaultValueSql("GetDate()");
                }
            
            }
            //modelBuilder.ApplyConfiguration(new CustomerMap());
            //modelBuilder.Entity<Customer>().Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
     //   public DbSet<Customer>Customers { get; set; }
    }
}
