using System.Threading.Tasks;

namespace WebAPI.Infrastructure.Repositories
{
    public interface IRepositoryWrapper
    {
        IRelationsRepository Relation { get; }

        IRelationsAddressesRepository Address { get; }
        Task SaveAsync();
    }
}
