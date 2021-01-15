using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain.Models;
using WebAPI.Domain.ViewModels.Relation;
using WebAPI.Domain.Queries;

namespace WebAPI.Domain.Interfaces.Services
{
    /// <summary>
    /// Describes services used by API controller
    /// </summary>
    public interface IRelationsService
    {
        /// <summary>
        ///  Service getting selected relations constrained by provided required arguments.
        /// </summary>
        Task<IEnumerable<RelationDetailsViewModel>> GetRelations(QueryParameters queryParameters);
        /// <summary>
        /// Service getting single selected relation by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RelationDetailsViewModel> GetRelationsById(Guid id);
        /// <summary>
        /// Service to update selected relation in db.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="relationModel"></param>
        /// <returns></returns>
        Task<RelationDetailsEditModel> EditModel(Guid id, RelationDetailsEditModel relationModel);
        /// <summary>
        /// Service to create new relation in db.
        /// </summary>
        /// <param name="relationModel"></param>
        /// <returns></returns>
        Task<RelationDetailsViewModel> CreateModel(RelationDetailsCreateModel relationModel);
        /// <summary>
        /// Service to delete selected relation in db by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Relation> DeleteModel(params Guid[] id);
    }
}
