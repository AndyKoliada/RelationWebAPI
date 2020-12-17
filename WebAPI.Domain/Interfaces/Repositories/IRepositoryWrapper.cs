using System.Threading.Tasks;

namespace WebAPI.Domain.Interfaces.Repositories
{   
    /// <summary>
    /// Unit of work wrapper
    /// </summary>
    public interface IRepositoryWrapper
    {   
        /// <summary>
        /// Abstract repository
        /// </summary>
        IRelationsRepository Relations { get; }

        /// <summary>
        /// Method for updating DB as unit of work
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}
