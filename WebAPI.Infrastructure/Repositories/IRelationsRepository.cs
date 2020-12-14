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
        Task<ActionResult<IEnumerable<RelationDetailsViewModel>>> GetRelation
            (int pageNumber, int pageSize, string sortBy, bool orderByDescending, string filterBy);
        Task<ActionResult<RelationDetailsViewModel>> GetRelationById(Guid relationId);
        public Task<ActionResult<RelationDetailsCreateModel>> PostRelation(RelationDetailsCreateModel relationModel);
        public Task<IActionResult> PutRelation(Guid id, RelationDetailsEditModel relationModel);
        public Task<ActionResult<Relation>> DeleteRelation(Guid id);
    }
}
