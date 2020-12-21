using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain.Models;
using WebAPI.Domain.ViewModels.Relation;
using WebAPI.Domain.Queries;

namespace WebAPI.Domain.Interfaces.Services
{
    /// <summary>
    /// Describes services used by API controller
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        ///  Service getting selected relations constrained by provided required arguments.
        /// </summary>
        Task<IEnumerable<string>> GetCountries();
    }
}
