using System.Linq;
using Common;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class EfContext : IDbContext
    {
        private readonly DbContext dbContext;

        public EfContext(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public void Delete<T>(T entity) where T : class
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void CreateOrUpdate<T>(T entity) where T : class
        {
            dbContext.Set<T>().Attach(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            dbContext.Set<T>().Update(entity);
        }

        public void Create<T>(T entity) where T : class
        {
            dbContext.Set<T>().Add(entity);
        }

        public object Original => dbContext;

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}