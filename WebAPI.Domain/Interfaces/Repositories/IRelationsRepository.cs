using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Models;
using WebAPI.Domain.ViewModels.Relation;

namespace WebAPI.Domain.Interfaces.Repositories
{
    /// <summary>
    /// todo add doc
    /// </summary>
    public interface IRelationsRepository : IRepositoryBase<Relation>
    {
        /// <summary>
        ///  todo add doc
        /// </summary>
        Task<IEnumerable<RelationDetailsViewModel>> GetRelationsAsync(int pageNumber, int pageSize, string sortBy, bool orderByDescending, string filterBy);

        Task<RelationDetailsCreateModel> PostRelationAsync(RelationDetailsCreateModel relationModel);
        Task<RelationDetailsEditModel> PutRelation(Guid id, RelationDetailsEditModel relationModel);
        Task<Relation> DeleteRelation(Guid id);
        Task<RelationDetailsViewModel> GetRelationByIdAsync(Guid id);
        bool RelationExists(Guid id);
    }
}
