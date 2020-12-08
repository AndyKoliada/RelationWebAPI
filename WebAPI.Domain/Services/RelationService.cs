using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Services
{
    class RelationService : IRelationService
    {
        public async Task<ActionResult<IEnumerable<>>> GetRelation(int pageNumber, int pageSize, string sortBy, bool orderByDescending, string filterBy)
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
    }
}
