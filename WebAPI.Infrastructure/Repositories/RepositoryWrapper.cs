using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Interfaces.Repositories;
using WebAPI.Infrastructure.Context;

namespace WebAPI.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _context;
        private IRelationsRepository _relations;
        private IRelationsAddressesRepository _addresses;
        public IRelationsRepository Relations
        {
            get
            {
                if (_relations == null)
                {
                    _relations = new RelationsRepository(_context);
                }
                return _relations;
            }
        }

        public IRelationsAddressesRepository Addresses
        {
            get
            {
                if (_addresses == null)
                {
                    _addresses = new RelationsAddressesRepository(_context);
                }
                return _addresses;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
