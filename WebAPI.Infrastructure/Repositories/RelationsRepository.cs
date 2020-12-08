using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using WebAPI.Domain.Models;
using WebAPI.Domain.ViewModels.Relation;
using WebAPI.Infrastructure.Context;

namespace WebAPI.Infrastructure.Repositories
{
    public class RelationsRepository : RepositoryBase<Relation>, IRelationsRepository
    {
        private readonly RepositoryContext _context;
        public RelationsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _context = repositoryContext;
        }

        public async Task<ActionResult<IEnumerable<RelationDetailsViewModel>>> GetRelation(int pageNumber, int pageSize, string sortBy, bool orderByDescending, string filterBy)
        {
            string orderQuery = sortBy;

            string filterQuery = filterBy;

            if (filterBy == "None")
            {
                filterQuery = null;
            }

            if (orderByDescending)
            {
                orderQuery += " descending";
            }

            return await _context.Relations.Where(d => d.IsDisabled == false && d.RelationCategory.Category.Name == filterQuery).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                                    .Include(a => a.RelationAddress).Select(v => new RelationDetailsViewModel
                                    {
                                        Id = v.Id,
                                        Name = v.Name,
                                        FullName = v.FullName,
                                        TelephoneNumber = v.TelephoneNumber,
                                        EmailAddress = v.EmailAddress,
                                        Country = v.RelationAddress.CountryName,
                                        City = v.RelationAddress.City,
                                        Street = v.RelationAddress.Street,
                                        StreetNumber = v.RelationAddress.Number,
                                        PostalCode = v.RelationAddress.PostalCode
                                    }).OrderBy(orderQuery).ToListAsync();
        }

        public async Task<Relation> GetRelationByIdAsync(Guid ownerId)
        {
            return await FindByCondition(owner => owner.Id.Equals(ownerId))
                .FirstOrDefaultAsync();
        }

        public async Task<Relation> GetRelationWithDetailsAsync(Guid ownerId)
        {
            return await FindByCondition(owner => owner.Id.Equals(ownerId))
                .Include(ac => ac.Accounts)
                .FirstOrDefaultAsync();
        }

        public void CreateRelation(Relation owner)
        {
            Create(owner);
        }

        public void UpdateRelation(Relation owner)
        {
            Update(owner);
        }

        public void DeleteRelation(Relation owner)
        {
            Delete(owner);
        }
    }
}
