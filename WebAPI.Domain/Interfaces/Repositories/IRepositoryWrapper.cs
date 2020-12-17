using System.Threading.Tasks;

namespace WebAPI.Domain.Interfaces.Repositories
{   
    /// <summary>
    /// Unit of work wrapper
    /// </summary>
    public interface IRepositoryWrapper
    {
        IRelationsRepository Relations { get; }
        Task SaveAsync();
    }
}
