namespace NH
{
    using System.Data;

    using Core;

    using Models;

    using NHibernate;

    public class NhUnitOfWork : IUnitOfWork
    {
        private ITransaction transaction;

        private ISession nhsession;

        public NhUnitOfWork(ISessionFactory sessionFactory)
        {
            this.nhsession = sessionFactory.OpenSession();
            transaction = this.nhsession.BeginTransaction();
            this.DbContext = new NhContext(this.nhsession);
            //var mm = this.nhsession.CreateCriteria(typeof(Country)).List<Country>();
            //var module = this.nhsession.Get<TModule>("MOD_20130701111346_695c4f96-adb8-4398-b");
        }


        #region IUnitOfWork Members

        public void Dispose()
        {
            SaveChanges();
            nhsession.Dispose();
        }

        public void SaveChanges()
        {
            this.nhsession.Flush();
            transaction.Commit();
        }

        public IDbContext DbContext { get; }

        #endregion
    }
}