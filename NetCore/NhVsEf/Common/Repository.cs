using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext context;

        public Repository(IDbContext context)
        {
            this.context = context;
        }


        public IQueryable<T> Read()
        {
            return this.context.Query<T>();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return this.Read().Where(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return this.Read().Where(predicate).SingleOrDefault();
        }

        public void Create(T entity)
        {
            this.context.Create(entity);
        }

        public void Update(T entity)
        {
            this.context.Update(entity);
        }

        public void Delete(T entity)
        {
            this.context.Delete(entity);
        }
    }
}