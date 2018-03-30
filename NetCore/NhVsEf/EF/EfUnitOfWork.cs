using Common;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private DbContext dbContext;

        public EfUnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.DbContext = new EfContext(this.dbContext);
        }

        public void Dispose()
        {
            this.SaveChanges();
            this.dbContext.Dispose();
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        public IDbContext DbContext { get; }
    }
}