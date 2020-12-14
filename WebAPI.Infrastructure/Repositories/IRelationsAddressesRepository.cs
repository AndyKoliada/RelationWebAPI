using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Models;

namespace WebAPI.Infrastructure.Repositories
{
    public interface IRelationsAddressesRepository : IRepositoryBase<RelationAddress>
    {
        //Task<ActionResult<IEnumerable<RelationAddress>>> GetAddresses();
        Task<ActionResult<RelationAddress>> GetAddressById(Guid relationId);
        public void PostAddress(RelationAddress address);
        public void PutAddress(Guid id, RelationAddress address);
        public void DeleteAddress(Guid id);
    }
}
