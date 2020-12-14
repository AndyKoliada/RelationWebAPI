﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain.Interfaces.Repositories;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.ViewModels.Relation;

namespace WebAPI.Services
{

    /// <inheritdoc/> 
    public class RelationsService : IRelationsService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RelationsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <inheritdoc/> 
        public async Task<IEnumerable<RelationDetailsViewModel>> GetRelations(int pageNumber, int pageSize, string sortBy, bool orderByDescending, string filterBy)
        {
            var relations = await _repositoryWrapper.Relations.GetRelationsAsync(pageNumber, pageSize, sortBy, orderByDescending, filterBy);

            return relations;
        }

        public async Task<RelationDetailsViewModel> GetRelationsById(Guid id)
        {
            var relation = await _repositoryWrapper.Relations.
        }
    }
}
