namespace NH
{
    using Core;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using Mappings;
    using Models;

    using NHibernate;
    using NHibernate.Tool.hbm2ddl;

    public class NhUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private ISessionFactory sessionFactory;

        public NhUnitOfWorkFactory()
        {
            this.sessionFactory = Fluently.Configure()
               .Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("CountriesContext")).ShowSql())
               .Mappings(
                   x =>
                       {
                           //x.AutoMappings.Add()
                           x.FluentMappings.AddFromAssemblyOf<ModuleMapping>();
                       })
               .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
               
               .BuildSessionFactory()
               ;
        }

        public IUnitOfWork Create()
        {
            return new NhUnitOfWork(this.sessionFactory);
        }
    }
}