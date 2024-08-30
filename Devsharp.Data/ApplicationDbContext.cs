using Microsoft.EntityFrameworkCore;
using Project.Core.Domain;
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
        public DbSet<Customer>Customers { get; set; }
    }
}
