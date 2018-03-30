using Common;

namespace NH
{
    using System.Linq;
    
    using NHibernate;
    using NHibernate.Linq;

    public class NhContext: IDbContext
    {
        private readonly ISession session;

        public NhContext(ISession session)
        {
            this.session = session;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return this.session.Query<T>();
        }

        public void Delete<T>(T entity) where T : class
        {
            this.session.Delete(entity);
        }

        public void CreateOrUpdate<T>(T entity) where T : class
        {
            this.session.SaveOrUpdate(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this.session.SaveOrUpdate(entity);
        }

        public void Create<T>(T entity) where T : class
        {
            this.session.SaveOrUpdate(entity);
        }

        public object Original => this.session;

        public void Dispose()
        {
            this.session.Dispose();
        }
    }
}