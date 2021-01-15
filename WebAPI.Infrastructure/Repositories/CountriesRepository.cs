using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain.Interfaces.Repositories;
using WebAPI.Domain.Models;
using WebAPI.Infrastructure.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Infrastructure.Repositories
{
    public class CountriesRepository : RepositoryBase<Country>, ICountriesRepository
    {
        private readonly RepositoryContext _context;

        public CountriesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _context = repositoryContext;
        }
        public async Task<IEnumerable<string>> GetCountriesAsync()
        {
            IEnumerable<string> countries = await _context.Countries.Where(c => c.Name != null).Select(c => c.Name).ToListAsync();
            return countries;
        }
    }
}
