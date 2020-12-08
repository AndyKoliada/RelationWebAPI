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
        //private IAccountRepository _account;
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
        //public IAccountRepository Account
        //{
        //    get
        //    {
        //        if (_account == null)
        //        {
        //            _account = new AccountRepository(_repoContext);
        //        }
        //        return _account;
        //    }
        //}
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
