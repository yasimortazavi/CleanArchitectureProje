using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Devsharp.Core.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using Devsharp.Core.Domian;
using System.Security.Cryptography.X509Certificates;

namespace Devsharp.Data
{
    public class ApplicationDbContext : DbContext, IApplcationDbContext
    {
        public ApplicationDbContext( DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=shop;Integrated Security=True;");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.SetMapDate();
            modelBuilder.PluralizeTable();
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new CustomerMap());
            //modelBuilder.Entity<Customer>().Property(x => x.FirstName).HasMaxLength(50).IsRequired();
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity.GetType().GetInterfaces().Any(p => p.Name == "IDateEntity"))
            {
                Entry((entity as IDateEntity).CreateOn).State = EntityState.Unchanged;
                (entity as IDateEntity).UpdateOn = DateTime.Now;
            }

            return base.Update(entity);
        }

           //public DbSet<Customer>Customers { get; set; }
    }
}
