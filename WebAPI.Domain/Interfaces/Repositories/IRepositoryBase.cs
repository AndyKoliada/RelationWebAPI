using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebAPI.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Abstract generic repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Generic method for getting all the entities.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> FindAll();

        /// <summary>
        /// Generic method for searching entities by condition expression.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Generic method for creation of new entity.
        /// </summary>
        /// <returns></returns>
        void Create(T entity);

        /// <summary>
        /// Generic method for updating the entity.
        /// </summary>
        /// <returns></returns>
        void Update(T entity);

        /// <summary>
        /// Generic method for deleting the entity.
        /// </summary>
        /// <returns></returns>
        void Delete(T entity);
    }
}
