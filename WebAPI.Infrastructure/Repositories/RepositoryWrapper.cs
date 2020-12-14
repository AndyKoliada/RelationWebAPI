using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Context;

namespace WebAPI.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _context;
        private IRelationsRepository _relation;
        public IRelationsRepository Relation
        {
            get
            {
                if (_relation == null)
                {
                    _relation = new RelationsRepository(_context);
                }
                return _relation;
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
