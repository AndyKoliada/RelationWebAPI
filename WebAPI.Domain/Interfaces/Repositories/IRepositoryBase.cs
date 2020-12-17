using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebAPI.Domain.Interfaces.Repositories
{   
    /// <summary>
    /// Abstract generic repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
