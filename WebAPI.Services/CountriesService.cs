using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain.Interfaces.Repositories;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Services
{

    /// <inheritdoc/> 
    public class CountriesService : ICountriesService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public CountriesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <inheritdoc/> 
        public async Task<IEnumerable<string>> GetCountries()
        {
            var countries = await _repositoryWrapper.Countries.GetCountriesAsync();

            return countries;
        }
    }
}
