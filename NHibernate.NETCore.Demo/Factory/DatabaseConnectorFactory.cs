using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.NETCore.Demo.DatabaseMapping;
using NHibernate.Tool.hbm2ddl;

namespace NHibernate.NETCore.Demo.Factory
{
    public static class DatabaseConnectorFactory
    {
        public static ISessionFactory GetInstance(DatabaseConnectorType type, string connectionString)
        {
            IPersistenceConfigurer dbConfiguration = null;

            switch (type)
            {       
                case DatabaseConnectorType.MySQL:
                    dbConfiguration = MySQLConfiguration.Standard.ConnectionString(connectionString);
                    break;
                case DatabaseConnectorType.MSSQL2012:
                    dbConfiguration = MsSqlConfiguration.MsSql2012.ConnectionString(connectionString);
                    break;
            }

            var mapConfig = Fluently.Configure()
                .Database(dbConfiguration)
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<PersonMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            return mapConfig.BuildSessionFactory();
        }
    }

    public enum DatabaseConnectorType
    {
        MySQL,
        MSSQL2012
    }
}
