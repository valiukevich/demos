using Common;
using NHibernate;

namespace NH
{
    public class NhUnitOfWork : IUnitOfWork
    {
        private readonly ISession nhsession;
        private readonly ITransaction transaction;

        public NhUnitOfWork(ISessionFactory sessionFactory)
        {
            nhsession = sessionFactory.OpenSession();
            transaction = nhsession.BeginTransaction();
            DbContext = new NhContext(nhsession);
        }


        #region IUnitOfWork Members

        public void Dispose()
        {
            SaveChanges();
            nhsession.Dispose();
        }

        public void SaveChanges()
        {
            nhsession.Flush();
            transaction.Commit();
        }

        public IDbContext DbContext { get; }

        #endregion
    }
}