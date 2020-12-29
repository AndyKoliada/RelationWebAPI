using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain.Interfaces.Repositories;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Models;
using WebAPI.Domain.ViewModels.Relation;
using WebAPI.Domain.Queries;

namespace WebAPI.Services
{

    /// <inheritdoc/> 
    public class RelationsServiceCached : IRelationsService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RelationsServiceCached(IRepositoryWrapper repositoryWrapper, IMemoryCache cache)
        {
            _repositoryWrapper = repositoryWrapper;
            _cache = cache;
        }

        /// <inheritdoc/> 
        public async Task<IEnumerable<RelationDetailsViewModel>> GetRelations(QueryParameters queryParameters)
        {
            var relations = await _repositoryWrapper.Relations.GetRelationsAsync(queryParameters);
            return relations;
        }

        public async Task<RelationDetailsViewModel> GetRelationsById(Guid id)
        {
            RelationDetailsViewModel relation = null;

            if (!_cache.TryGetValue(id, out relation))
            {
                relation = await _repositoryWrapper.Relations.GetRelationByIdAsync(id);
                if (relation != null)
                {
                    _cache.Set(relation.Id, relation,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }
            return relation;
        }

        public async Task<RelationDetailsEditModel> EditModel(Guid id, RelationDetailsEditModel relationModel)
        {
            var relation = await _repositoryWrapper.Relations.PutRelation(id, relationModel);
            return relation;
        }

        public async Task<RelationDetailsViewModel> CreateModel(RelationDetailsCreateModel relationModel)
        {
            var relation = await _repositoryWrapper.Relations.PostRelationAsync(relationModel);
            return relation;
        }

        public async Task<Relation> DeleteModel(params Guid[] ids)
        {
            return await _repositoryWrapper.Relations.DeleteRelation(ids);
        }

        public bool RelationExists(Guid id)
        {
            return _repositoryWrapper.Relations.RelationExists(id);
        }
    }
}
