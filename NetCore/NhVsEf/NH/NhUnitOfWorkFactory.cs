using Common;
using NH.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace NH
{
    public class NhUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISessionFactory sessionFactory;

        public NhUnitOfWorkFactory()
        {
            var configuration = new Configuration();
            //configuration.SessionFactoryName("builtin");
            configuration.DataBaseIntegration(properties =>
            {
                properties.Dialect<MsSql2008Dialect>();
                properties.Driver<SqlClientDriver>();
                properties.ConnectionString = "Server=.;Database=Demo;integrated security=True;MultipleActiveResultSets=True;";

                properties.LogSqlInConsole = true;
                properties.LogFormattedSql = true;
            });
            var mapping = GetAllMappings();
            configuration.AddDeserializedMapping(mapping, "NHByCodeTest");
            //SchemaMetadataUpdater.QuoteTableAndColumns(configuration, new MsSql2008Dialect());
            sessionFactory = configuration.BuildSessionFactory();


        }

        public IUnitOfWork Create()
        {
            return new NhUnitOfWork(sessionFactory);
        }

        private HbmMapping GetAllMappings()
        {
            ModelMapper mapper = new ModelMapper();
            mapper.AddMappings(typeof(CountryMapping).Assembly.GetExportedTypes());
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            return mapping;
        }
    }
}