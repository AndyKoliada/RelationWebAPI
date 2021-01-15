using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using WebAPI.Domain.Interfaces.Repositories;
using WebAPI.Domain.Models;
using WebAPI.Domain.ViewModels.Relation;
using WebAPI.Infrastructure.Context;
using WebAPI.Domain.Queries;

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

        public async Task<IEnumerable<RelationDetailsViewModel>> GetRelationsAsync(QueryParameters queryParameters)
        {
            string orderQuery = queryParameters.SortBy;
            string filterQuery = queryParameters.FilterBy;

            if (queryParameters.FilterBy == "None")
            {
                filterQuery = null;
            }

            if (queryParameters.OrderByDescending)
            {
                orderQuery += " descending";
            }

            var relations = await _context.Relations
                .Where(d => d.IsDisabled == false && d.RelationCategory.Category.Name == filterQuery)
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .Include(a => a.RelationAddress)
                .Select(v => 
                new RelationDetailsViewModel
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
                })
                .OrderBy(orderQuery)
                .ToListAsync();

            return relations;
        }

        public async Task<RelationDetailsViewModel> GetRelationByIdAsync(Guid id)
        {
            var relation = await _context.Relations.Where(d => d.Id == id).Select(v => new RelationDetailsViewModel
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
            }).FirstOrDefaultAsync();

            return relation;
        }

        public async Task<RelationDetailsViewModel> PostRelationAsync(RelationDetailsCreateModel relationModel)
        {
            TryFormatPostalCode(relationModel);

            Relation relation = new Relation()
            {
                Id = relationModel.Id,
                Name = relationModel.Name,
                FullName = relationModel.FullName,
                TelephoneNumber = relationModel.TelephoneNumber,
                EmailAddress = relationModel.EmailAddress
            };

            RelationAddress relationAddress = new RelationAddress()
            {
                RelationId = relation.Id,
                CountryName = relationModel.Country,
                City = relationModel.City,
                Street = relationModel.Street,
                Number = relationModel.StreetNumber,
                PostalCode = relationModel.PostalCode
            };

            _context.Relations.Add(relation);
            _context.RelationAddresses.Add(relationAddress);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (RelationExists(relation.Id))
                {
                    throw ex;
                }
                else
                {
                    throw;
                }
            }

            RelationDetailsViewModel relationView = await _context.Relations.Where(r => r.Id == relation.Id).Select(v => new RelationDetailsViewModel
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
            }).FirstOrDefaultAsync();

            return relationView;
        }

        public async Task<RelationDetailsEditModel> PutRelation(Guid id, RelationDetailsEditModel relationModel)
        {

            Relation relation = new Relation()
            {
                Id = id,
                Name = relationModel.Name,
                FullName = relationModel.FullName,
                TelephoneNumber = relationModel.TelephoneNumber,
                EmailAddress = relationModel.EmailAddress
            };

            RelationAddress relationAddress = new RelationAddress()
            {
                RelationId = id,
                CountryName = relationModel.Country,
                City = relationModel.City,
                Street = relationModel.Street,
                Number = relationModel.StreetNumber,
                PostalCode = relationModel.PostalCode
            };

            _context.Entry(relation).State = EntityState.Modified;
            _context.Entry(relationAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!RelationExists(id))
                {
                    throw ex;
                }
                else
                {
                    throw;
                }
            }

            return relationModel;
        }

        public async Task<Relation> DeleteRelation(params Guid[] ids)
        {
            Relation relation = null;
            foreach(Guid id in ids) {

                relation = await _context.Relations.FindAsync(id);

                if (relation == null)
                {
                    throw new Exception($"{id} Not found");
                }

                relation.IsDisabled = true;
            }

            await _context.SaveChangesAsync();
            return relation;
        }

        public bool RelationExists(Guid id)
        {
            return _context.Relations.Any(e => e.Id == id);
        }

        public RelationDetailsCreateModel TryFormatPostalCode(RelationDetailsCreateModel relationModel)
        {
            string postalCodeMask = GetPostalCodeMask(relationModel);

            relationModel.PostalCode = ModifyPostalCode(relationModel.PostalCode, postalCodeMask);

            return relationModel;
        }

        public string GetPostalCodeMask(RelationDetailsCreateModel relationModel)
        {
            string postalCodeFormatMask;

            if (relationModel.PostalCode != null && relationModel.Country != null)
            {
                postalCodeFormatMask = _context.Countries
                    .Where(n => n.Name == relationModel.Country && n.PostalCodeFormat != null)
                    .Select(n => n.PostalCodeFormat).FirstOrDefault();

                if (postalCodeFormatMask != null)
                {
                    return postalCodeFormatMask;
                }
                else return "";

            }
            else return "";
        }

        public string ModifyPostalCode(string input, string mask)
        { 
            if(String.IsNullOrEmpty(input))
            {
                return "";
            }
            string correctedPostalCode = "";
            string pc = new string(input.ToCharArray()
                    .Where(c => !Char.IsWhiteSpace(c))
                    .ToArray());
            string m = mask;

            for (int i = 0, j = 0; i < pc.Length && j < m.Length; i++)
            {
                if (Char.IsDigit(pc[i]) && m[j] == 'N')
                {
                    correctedPostalCode += pc[i];
                    j++;
                }
                else if (!Char.IsLetterOrDigit(pc[i]) && !Char.IsLetterOrDigit(m[j]) && m[j] != pc[i])
                {
                    correctedPostalCode += m[j];
                    j++;
                }
                else if (!Char.IsLetterOrDigit(pc[i]) && !Char.IsLetterOrDigit(m[j]) && m[j] == pc[i])
                {
                    correctedPostalCode += pc[i];
                    j++;
                }
                else if (Char.IsLetter(pc[i]) && m[j] == 'l')
                {
                    correctedPostalCode += Char.ToLower(pc[i]);
                    j++;
                }
                else if (Char.IsLetter(pc[i]) && m[j] == 'L')
                {
                    correctedPostalCode += Char.ToUpper(pc[i]);
                    j++;
                }

            }

            if (correctedPostalCode.Length < pc.Length)
            {
                return pc;
            }
            else
            {
                return correctedPostalCode;
            }
        }
    }
}
