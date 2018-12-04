using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NHibernate.NETCore.Demo.Repository.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        bool Create(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(object id);

        TEntity Get(object id);

        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> query);
    }
}
