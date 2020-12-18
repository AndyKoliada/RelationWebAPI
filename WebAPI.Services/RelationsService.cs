//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using WebAPI.Domain.Interfaces.Repositories;
//using WebAPI.Domain.Interfaces.Services;
//using WebAPI.Domain.Models;
//using WebAPI.Domain.ViewModels.Relation;

//namespace WebAPI.Services
//{

//    /// <inheritdoc/> 
//    public class RelationsService : IRelationsService
//    {
//        private readonly IRepositoryWrapper _repositoryWrapper;

//        /// <summary>
//        /// Constructor.
//        /// </summary>
//        public RelationsService(IRepositoryWrapper repositoryWrapper)
//        {
//            _repositoryWrapper = repositoryWrapper;
//        }

//        /// <inheritdoc/> 
//        public async Task<IEnumerable<RelationDetailsViewModel>> GetRelations(int pageNumber, int pageSize, string sortBy, bool orderByDescending, string filterBy)
//        {
//            var relations = await _repositoryWrapper.Relations.GetRelationsAsync(pageNumber, pageSize, sortBy, orderByDescending, filterBy);

//            return relations;
//        }

//        public async Task<RelationDetailsViewModel> GetRelationsById(Guid id)
//        {
//            var relation = await _repositoryWrapper.Relations.GetRelationByIdAsync(id);

//            return relation;
//        }

//        public async Task<RelationDetailsEditModel> EditModel(Guid id, RelationDetailsEditModel relationModel)
//        {
//            var relation = await _repositoryWrapper.Relations.PutRelation(id, relationModel);

//            return relation;
//        }

//        public async Task<RelationDetailsCreateModel> CreateModel(RelationDetailsCreateModel relationModel)
//        {
//            var relation = await _repositoryWrapper.Relations.PostRelationAsync(relationModel);

//            return relation;
//        }

//        public async Task<Relation> DeleteModel(Guid id)
//        {
//            var relation = await _repositoryWrapper.Relations.DeleteRelation(id);

//            return relation;
//        }



//        public bool RelationExists(Guid id)
//        {
//            return _repositoryWrapper.Relations.RelationExists(id);
//        }

//    }
//}
