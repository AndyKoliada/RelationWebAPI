using System.Threading.Tasks;

namespace WebAPI.Domain.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IRelationsRepository Relations { get; }
        IRelationsAddressesRepository Addresses { get; }
        Task SaveAsync();
    }
}
