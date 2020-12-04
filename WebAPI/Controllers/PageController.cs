using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ModelsConnected;
using WebAPI.ModelsConnected.ViewModel;
using WebAPI.Service;
using WebAPI.ViewModel.RelationAddress;
//http://api.example.com/device-management/managed-devices?region=USA&brand=XYZ URI Query example for filtering

//https://www.youtube.com/watch?v=3BsTfc_pv_4 Watch this in the morning
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly TestDBContext _context;
        private readonly IMapper _mapper;

        public PageController(TestDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
 
        [HttpGet]
        [Route("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<RelationDetailsViewModel>>> GetRelation(int pageNumber, int pageSize) 
        {

            return  await _context.Relations.Where(d => d.IsDisabled == false).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                                    .Include(a => a.RelationAddress).Select(v => new RelationDetailsViewModel {
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
                                    }).ToListAsync();


        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Relation>> GetRelation(Guid id)
        {
            var relation = await _context.Relations.FindAsync(id);

            if (relation == null)
            {
                return NotFound();
            }

            return relation;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelation(Guid id, RelationDetailsEditModel relationModel)
        {
            //#region Initialize required DB fields on Update
            //relation.ModifiedAt = DateTime.Now;
            //#endregion

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

            //_context.Relations.Add(relation);
            //_context.RelationAddresses.Add(relationAddress);

            if (id != relation.Id)
            {
                return BadRequest();
            }

            _context.Entry(relation).State = EntityState.Modified;
            _context.Entry(relationAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Relations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RelationDetailsCreateModel>> PostRelation(RelationDetailsCreateModel relationModel)
        {
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
                City = relationModel.Name,
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
            catch (DbUpdateException)
            {
                if (RelationExists(relation.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRelation", new { id = relation.Id }, relation);
        }

        // DELETE: api/Relations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Relation>> DeleteRelation(Guid id)
        {
            var relation = await _context.Relations.FindAsync(id);
            if (relation == null)
            {
                return NotFound();
            }

            #region Implemented Soft Delete
            relation.IsDisabled = true;
            

            //_context.TblRelation.Remove(tblRelation);
            #endregion
            await _context.SaveChangesAsync();

            return relation;
        }

        private bool RelationExists(Guid id)
        {
            return _context.Relations.Any(e => e.Id == id);
        }
    }
}
