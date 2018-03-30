using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common
{
    public interface IRepository<T>
    {
        /// <summary>
        /// create a entity
        /// </summary>
        /// <param name="entity">the entity to create</param>
        void Create(T entity);

        /// <summary>
        /// Read entities
        /// </summary>
        /// <returns>an iqueryable of entities</returns>
        IQueryable<T> Read();
        
        /// <summary> 
        /// Where condition 
        /// </summary> 
        /// <param name="predicate">where condition</param> 
        /// <returns>an iqueryable of entities</returns> 
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        /// <summary> 
        /// Read entity with where condition 
        /// </summary> 
        /// <param name="predicate">where condition</param> 
        /// <returns>an entity or null</returns> 
        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entity">the entity to be updated</param>
        void Update(T entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entity">the entity to delete</param>
        void Delete(T entity);
    }
}