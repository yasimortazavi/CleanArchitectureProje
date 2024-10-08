﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devsharp.Data
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields
        private readonly IApplcationDbContext _context = null;
        private DbSet<TEntity> entities = null;
        protected virtual DbSet<TEntity> Entities
        {
            get
            { 
                if(entities == null)
                   entities = _context.Set<TEntity>();

                return entities;
            
            }
        
        }
        #endregion
        public EFRepository(IApplcationDbContext context) 
        {
            this._context = context;
        }
        public IQueryable<TEntity> Table => Entities;

        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public void Delete(TEntity entity)
        {
            if(entity==null)
                 throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public TEntity GetById(params object[] ids)
        {
            return _context.Set<TEntity>().Find(ids);
        }

        public TEntity GetByIdAsNoTracking(params object[] ids)
        {
            var X = _context.Set<TEntity>().Find(ids);
            if(X!=null)
              this._context.Entry(X).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return X;
         
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Remove(entity);
          await  _context.SaveChangesAsync();
        }
        public async Task<TEntity> GetByIdAsync(params object[] ids)
        {
            return await _context.Set<TEntity>().FindAsync(ids);
        }

        public async Task<TEntity> GetByIdAsNoTrackingAsync(params object[] ids)
        {
            var X =  await _context.Set<TEntity>().FindAsync(ids);
            if (X != null)
                 this._context.Entry(X).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return X;

        }
        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

           await  _context.Set<TEntity>().AddAsync(entity);
           await  _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Update(entity);
            await  _context.SaveChangesAsync();
        }
    }

}
