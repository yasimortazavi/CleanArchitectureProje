using Microsoft.EntityFrameworkCore;
using Devsharp.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using Devsharp.Core.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.PluralizeTable();
            //modelBuilder.ApplyConfiguration(new CustomerMap());
            //modelBuilder.Entity<Customer>().Property(x => x.FirstName).HasMaxLength(50).IsRequired();
        }
        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity.GetType().GetInterfaces().Any(p => p.Name == "IDateEntity"))
            {
                Entry((entity as IDateEntity).CreateDate).State = EntityState.Unchanged;
                (entity as IDateEntity).EditDate = DateTime.Now;
            }

            return base.Update(entity);
        }

        //   public DbSet<Customer>Customers { get; set; }
    }
}
