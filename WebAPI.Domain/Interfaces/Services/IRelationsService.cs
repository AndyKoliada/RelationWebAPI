using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain.ViewModels.Relation;

namespace WebAPI.Domain.Interfaces.Services
{
    /// <summary>
    /// todo: add documentation
    /// </summary>
    public interface IRelationsService
    {
        /// <summary>
        ///  todo: add documentation
        /// </summary>
        Task<IEnumerable<RelationDetailsViewModel>> GetRelations(int pageNumber, int pageSize, string sortBy, bool orderByDescending, string filterBy);

        Task<RelationDetailsViewModel> GetRelationsById(Guid id);

        Task<RelationDetailsEditModel> EditModel(Guid id, RelationDetailsEditModel relationModel);
    }
}
