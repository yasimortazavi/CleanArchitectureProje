using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devsharp.Data
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields
        private readonly IApplcationDbContext _context = null;
        #endregion
        public EFRepository(IApplcationDbContext context) 
        {
            this._context = context;
        }
        public IQueryable<TEntity> Table => throw new NotImplementedException();

        public IQueryable<TEntity> TableNoTracking => throw new NotImplementedException();

        public void Delete(TEntity entity)
        {
            if(entity==null)
                 throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public TEntity GetById(object id)
        {
            throw new NotImplementedException();
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
    }
}
