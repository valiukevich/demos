using System.Linq;

namespace Common
{
    public interface IDbContext
    {
        IQueryable<T> Query<T>() where T : class;

        void Delete<T>(T entity) where T : class;

        void CreateOrUpdate<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Create<T>(T entity) where T : class;

        object Original { get; }
    }
}