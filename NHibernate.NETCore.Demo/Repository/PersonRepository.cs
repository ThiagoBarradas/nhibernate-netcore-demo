using NHibernate.NETCore.Demo.Models;
using NHibernate.NETCore.Demo.Repository.Interfaces;

namespace NHibernate.NETCore.Demo.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }
    }
}
