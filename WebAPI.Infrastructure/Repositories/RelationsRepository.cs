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

        public async Task<ActionResult<IEnumerable<RelationDetailsViewModel>>> GetRelationsAsync(int pageNumber, int pageSize, string sortBy, bool orderByDescending, string filterBy)
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

        public async Task<ActionResult<RelationDetailsViewModel>> GetRelationByIdAsync(Guid id)
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

        public Task<IActionResult> PutRelation(Guid id, RelationDetailsEditModel relationModel)
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
                City = relationModel.Name,
                Street = relationModel.Street,
                Number = relationModel.StreetNumber,
                PostalCode = relationModel.PostalCode
            };

            //if (id != relation.Id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(relation).State = EntityState.Modified;
            _context.Entry(relationAddress).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RelationExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        public async Task<ActionResult<RelationDetailsCreateModel>> PostRelationAsync(RelationDetailsCreateModel relationModel)
        {

            string postalCodeFormatMask;


            if (relationModel.PostalCode != null && relationModel.Country != null)
            {
                postalCodeFormatMask = _context.Countries
                    .Where(n => n.Name == relationModel.Country && n.PostalCodeFormat != null)
                    .Select(n => n.PostalCodeFormat).FirstOrDefault();

                if (postalCodeFormatMask != null)
                {
                    relationModel.PostalCode = PostalCodeFormatter(postalCodeFormatMask);
                }

            }

            string PostalCodeFormatter(string postalCodeFormatMask)
            {
                //Расшифровка символов маски: N - digit, L - capital letter,
                //l - lower letter.Например, если введенный почтовый индекс 4545bx,
                //    а маска -"NNNN-LL", то в базе должно сохраниться значение 4545 - BX

                string correctedPostalCode = "";
                string pc = new string(relationModel.PostalCode.ToCharArray()
                        .Where(c => !Char.IsWhiteSpace(c))
                        .ToArray());
                string m = postalCodeFormatMask;


                //for (int i = 0; i < m.Length && correctedPostalCode.Length <= pc.Length; i++)
                //{
                //        if (m[i] == 'N' && Char.IsDigit(pc[i]))
                //        {
                //            correctedPostalCode += pc[i];
                //        }
                //        else if (m[i] == 'l' && Char.IsLetter(pc[i]) && Char.IsLower(pc[i]))
                //        {
                //            correctedPostalCode += pc[i];
                //        }
                //        else if (m[i] == 'L' && Char.IsLetter(pc[i]) && Char.IsUpper(pc[i]))
                //        {
                //            correctedPostalCode += pc[i];
                //        }
                //        else if (m[i] == 'l' && Char.IsLetter(pc[i]) && Char.IsUpper(pc[i]))
                //        {
                //            correctedPostalCode += Char.ToLower(pc[i]);
                //        }
                //        else if (m[i] == 'L' && Char.IsLetter(pc[i]) && Char.IsLower(pc[i]))
                //        {
                //            correctedPostalCode += Char.ToUpper(pc[i]);
                //        }
                //        else if (!Char.IsLetterOrDigit(m[i]) && m[i] != pc[i])
                //        {
                //            correctedPostalCode += " " + m[i] + " ";
                //        }
                //        else
                //        {
                //        correctedPostalCode += pc[i];
                //        }
                //}
                for (int i = 0, j = 0; i < pc.Length && j < m.Length; i++)
                {
                    if (Char.IsDigit(pc[i]) && m[j] == 'N')
                    {
                        correctedPostalCode += pc[i];
                        j++;
                    }
                    else if (!Char.IsLetterOrDigit(pc[i]) && !Char.IsLetterOrDigit(m[j]) && m[j] != pc[i])
                    {
                        correctedPostalCode += " " + m[j] + " ";
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
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (RelationExists(relation.Id))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtAction("GetRelation", new { id = relation.Id }, relation);
        }

        public async Task<ActionResult<Relation>> DeleteRelation(Guid id)
        {
            var relation = await _context.Relations.FindAsync(id);
            //if (relation == null)
            //{
            //    return NotFound();
            //}

            #region Implemented Soft Delete
            relation.IsDisabled = true;


            //_context.TblRelation.Remove(tblRelation);
            #endregion
            await _context.SaveChangesAsync();

            return relation;
        }

        //private bool RelationExists(Guid id)
        //{
        //    return _context.Relations.Any(e => e.Id == id);
        //}
    }
}
