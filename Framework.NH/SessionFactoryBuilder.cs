using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Event;
using NHibernate.Mapping.ByCode;

namespace Framework.NH
{
    public static class SessionFactoryBuilder
    {
        public static ISessionFactory CreateByConnectionString(string connectionString, Assembly mappingAssembly)
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(cfg =>
            {
                cfg.Dialect<MsSql2012Dialect>();
                cfg.Driver<SqlClientDriver>();
                cfg.ConnectionString = connectionString;
                cfg.IsolationLevel = IsolationLevel.ReadCommitted;
            });
            return Create(configuration, mappingAssembly);
        }
        public static ISessionFactory CreateByConnectionStringName(string connectionStringName,Assembly mappingAssembly)
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(cfg =>
            {
                cfg.Dialect<MsSql2012Dialect>();
                cfg.Driver<SqlClientDriver>();
                cfg.ConnectionStringName = connectionStringName;
                cfg.IsolationLevel = IsolationLevel.ReadCommitted;
            });
            return Create(configuration, mappingAssembly);
        }

        private static ISessionFactory Create(Configuration configuration, Assembly mappingAssembly)
        {
            configuration.EventListeners.PreInsertEventListeners = new IPreInsertEventListener[]{new DomainEventListener()};
            configuration.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[]{new DomainEventListener()};

            var modelMapper = new ModelMapper();
            modelMapper.AddMappings(mappingAssembly.GetExportedTypes());

            var hbmMapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddDeserializedMapping(hbmMapping, "test");

            return configuration.BuildSessionFactory();
        }
    }
}
