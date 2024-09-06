using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devsharp.Data
{
    public partial interface IRepository<TEntity> where TEntity : class
    {

        TEntity GetById(params object[] ids);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> Table { get; }

        IQueryable<TEntity> TableNoTracking { get; }

    }
}
