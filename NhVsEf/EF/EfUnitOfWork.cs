//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EfUnitOfWork.cs" company="Noordhoff Uitgevers BV">
//      © Noordhoff Uitgevers BV, the Netherlands
//  </copyright>
//   <author>Valiukevich, Evgeny</author>
//  --------------------------------------------------------------------------------------------------------------------
namespace EF
{
    using System.Data.Entity;

    using Core;
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