using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Models;
using WebAPI.Domain.ViewModels.Relation;

namespace WebAPI.Infrastructure.Repositories
{
    public interface IRelationsRepository : IRepositoryBase<Relation>
    {
        Task<ActionResult<IEnumerable<RelationDetailsViewModel>>> GetRelation(int pageNumber, int pageSize, string sortBy, bool orderByDescending, string filterBy);
        //Task<IEnumerable<Relation>> GetAllRelationsAsync();
        Task<Relation> GetRelationByIdAsync(Guid relationId);
        Task<Relation> GetRelationWithDetailsAsync(Guid relationId);
        void CreateRelation(Relation relation);
        void UpdateRelation(Relation relation);
        void DeleteRelation(Relation relation);
    }
}
