using System.Threading.Tasks;

namespace WebAPI.Infrastructure.Repositories
{
    public interface IRepositoryWrapper
    {
        IRelationsRepository Relation { get; }
        Task SaveAsync();
    }
}
