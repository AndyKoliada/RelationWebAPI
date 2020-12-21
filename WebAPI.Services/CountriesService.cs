using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain.Interfaces.Repositories;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Models;
using WebAPI.Domain.ViewModels.Relation;
using WebAPI.Domain.Queries;

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
