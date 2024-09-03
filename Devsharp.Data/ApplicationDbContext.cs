using Microsoft.EntityFrameworkCore;
using Devsharp.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devsharp.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=.; initial Catalog=ShopCleanArhitector;integrated security = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetMapDate();
            //modelBuilder.ApplyConfiguration(new CustomerMap());
            //modelBuilder.Entity<Customer>().Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        //   public DbSet<Customer>Customers { get; set; }
    }
}
