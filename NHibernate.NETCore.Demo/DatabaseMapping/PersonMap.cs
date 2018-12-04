using FluentNHibernate.Mapping;
using NHibernate.NETCore.Demo.Models;

namespace NHibernate.NETCore.Demo.DatabaseMapping
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(p => p.Document);
            Map(p => p.Name);
            Table("Person");
        }
    }
}
