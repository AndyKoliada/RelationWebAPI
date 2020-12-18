using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain.Models;
using WebAPI.Domain.ViewModels.Relation;
using WebAPI.Domain.Queries;

namespace WebAPI.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Describes methods of generic repository.
    /// </summary>
    public interface IRelationsRepository : IRepositoryBase<Relation>
    {
        /// <summary>
        ///  Gets only reqired models from db. Constrained by provided arguments.
        /// </summary>
        Task<IEnumerable<RelationDetailsViewModel>> GetRelationsAsync(QueryParameters queryParameters);

        /// <summary>
        /// Creates new record in db.
        /// </summary>
        /// <param name="relationModel"></param>
        /// <returns></returns>
        Task<RelationDetailsCreateModel> PostRelationAsync(RelationDetailsCreateModel relationModel);

        /// <summary>
        /// Updates provided record in db by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="relationModel"></param>
        /// <returns></returns>
        Task<RelationDetailsEditModel> PutRelation(Guid id, RelationDetailsEditModel relationModel);

        /// <summary>
        /// Deletes record in db by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Relation> DeleteRelation(Guid id);

        /// <summary>
        /// Gets single record from db by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RelationDetailsViewModel> GetRelationByIdAsync(Guid id);

        /// <summary>
        /// Flag for record is in db.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool RelationExists(Guid id);
    }
}
