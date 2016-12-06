namespace Core
{
    using System;
    using System.Linq;

    public interface IDbContext
    {
        IQueryable<T> Query<T>() where T : class;

        void Delete<T>(T entity) where T : class;

        void CreateOrUpdate<T>(T entity) where T : class;

        object Original { get; }
    }
}