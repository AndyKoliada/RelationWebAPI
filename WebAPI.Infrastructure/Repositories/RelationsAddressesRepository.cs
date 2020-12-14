using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Interfaces.Repositories;
using WebAPI.Domain.Models;
using WebAPI.Infrastructure.Context;

namespace WebAPI.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class RelationsAddressesRepository : RepositoryBase<RelationAddress>, IRelationsAddressesRepository
    {
        private readonly RepositoryContext _context;
        public RelationsAddressesRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<RelationAddress>> GetAddresses()
        {
            throw new NotImplementedException();
        }

        //public async Task GetAddressById(Guid relationId)
        //{
        //    //return await _context.RelationAddresses.FindAsync(relationId);


        //    return await _repository.Address.FindByCondition(x => x.RelationId == relationId);
        //}
        //public void PostAddress(RelationAddress address)
        //{
        //   _context.RelationAddresses.Add(address);

        //}
        //public void PutAddress(Guid id, RelationAddress address)
        //{
        //    _context.Entry(address).State = EntityState.Modified;
        //}
        //public Task<ActionResult<Relation>> DeleteAddress(Guid id);
    }
}
