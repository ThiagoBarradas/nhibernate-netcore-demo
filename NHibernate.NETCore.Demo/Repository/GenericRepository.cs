using NHibernate.NETCore.Demo.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NHibernate.NETCore.Demo.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    {
        protected ISessionFactory SessionFactory { get; set; }

        public GenericRepository(ISessionFactory sessionFactory)
        {
            this.SessionFactory = sessionFactory;
        }

        public bool Create(TEntity entity)
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entity);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool Update(TEntity entity)
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool Delete(object id)
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(id);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public TEntity Get(object id)
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                return session.Get<TEntity>(id);
            }
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> query)
        {
            using (ISession session = this.SessionFactory.OpenSession())
            {
                return session.Query<TEntity>().Where(query).ToList();
            }
        }
    }
}
