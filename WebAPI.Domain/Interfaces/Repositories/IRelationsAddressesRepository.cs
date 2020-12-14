using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRelationsAddressesRepository : IRepositoryBase<RelationAddress>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RelationAddress>> GetAddresses();
        //Task<RelationAddress> GetAddressById(Guid relationId);
        //public void PostAddress(RelationAddress address);
        //public void PutAddress(Guid id, RelationAddress address);
        //public void DeleteAddress(Guid id);
    }
}
