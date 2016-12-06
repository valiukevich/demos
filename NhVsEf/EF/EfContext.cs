//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EfContext.cs" company="Noordhoff Uitgevers BV">
//      © Noordhoff Uitgevers BV, the Netherlands
//  </copyright>
//   <author>Valiukevich, Evgeny</author>
//  --------------------------------------------------------------------------------------------------------------------
namespace EF
{
    using System.Data.Entity;
    using System.Linq;

    using Core;
    public class EfContext : IDbContext
    {
        private readonly DbContext dbContext;

        public EfContext(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return this.dbContext.Set<T>();
        }

        public void Delete<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        public void CreateOrUpdate<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Attach(entity);
        }

        public object Original => this.dbContext;
    }
}