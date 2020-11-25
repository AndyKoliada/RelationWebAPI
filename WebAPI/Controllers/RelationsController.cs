using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationsController : ControllerBase
    {
        private readonly testContext _context;

        public RelationsController(testContext context)
        {
            _context = context;
        }

        // GET: api/Relations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRelation>>> GetTblRelation()
        {   
            return await _context.TblRelation.Where(a => a.IsDisabled == false).ToListAsync();
        }

        // GET: api/Relations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblRelation>> GetTblRelation(Guid id)
        {
            var tblRelation = await _context.TblRelation.FindAsync(id);

            if (tblRelation == null)
            {
                return NotFound();
            }

            return tblRelation;
        }

        // PUT: api/Relations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblRelation(Guid id, TblRelation tblRelation)
        {
            if (id != tblRelation.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblRelation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblRelationExists(id))
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
        public async Task<ActionResult<TblRelation>> PostTblRelation(TblRelation tblRelation)
        {
            tblRelation.Id = Guid.NewGuid();
            tblRelation.InvoiceDateGenerationOptions = 1;
            tblRelation.InvoiceGroupByOptions = 1;
            tblRelation.PaymentViaAutomaticDebit = false;
            tblRelation.IsMe = false;
            tblRelation.IsTemporary = false;
            tblRelation.IsDisabled = false;
            tblRelation.CreatedAt = DateTime.Now;
            tblRelation.CreatedBy = "Admin";


            _context.TblRelation.Add(tblRelation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblRelationExists(tblRelation.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblRelation", new { id = tblRelation.Id }, tblRelation);
        }

        // DELETE: api/Relations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblRelation>> DeleteTblRelation(Guid id)
        {
            var tblRelation = await _context.TblRelation.FindAsync(id);
            if (tblRelation == null)
            {
                return NotFound();
            }

            tblRelation.IsDisabled = true;

            //_context.TblRelation.Remove(tblRelation);
            await _context.SaveChangesAsync();

            return tblRelation;
        }

        private bool TblRelationExists(Guid id)
        {
            return _context.TblRelation.Any(e => e.Id == id);
        }
    }
}
