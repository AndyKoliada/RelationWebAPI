using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Models;
using WebAPI.Infrastructure.Context;

namespace WebAPI.Infrastructure.Repositories
{
    class RelationsAddressesRepository : RepositoryBase<RelationAddress>, IRelationsAddressesRepository
    {
        private readonly RepositoryContext _context;
        private IRepositoryWrapper _repository;
        public RelationsAddressesRepository(RepositoryContext repositoryContext, IRepositoryWrapper repository)
            : base(repositoryContext)
        {
            _context = repositoryContext;
            _repository = repository;
        }

        public async Task GetAddressById(Guid relationId)
        {
            //return await _context.RelationAddresses.FindAsync(relationId);


            return await _repository.Address.FindByCondition(x => x.RelationId == relationId);
        }
        public void PostAddress(RelationAddress address)
        {
           _context.RelationAddresses.Add(address);

        }
        public void PutAddress(Guid id, RelationAddress address)
        {
            _context.Entry(address).State = EntityState.Modified;
        }
        public Task<ActionResult<Relation>> DeleteAddress(Guid id);
    }
}
