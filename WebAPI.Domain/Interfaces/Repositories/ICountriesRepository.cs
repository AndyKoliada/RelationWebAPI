using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Describes methods of generic repository.
    /// </summary>
    public interface ICountriesRepository : IRepositoryBase<Country>
    {
        /// <summary>
        ///  Gets only reqired models from db. Constrained by provided arguments.
        /// </summary>
        Task<IEnumerable<string>> GetCountriesAsync();

    }
}
