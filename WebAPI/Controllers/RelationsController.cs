﻿using System;
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
        private readonly TestContext _context;

        public RelationsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Relations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relation>>> GetRelation()
        {
            return await _context.Relation.Where(a => a.IsDisabled == false).ToListAsync();
        }

        // GET: api/Relations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relation>> GetRelation(Guid id)
        {
            var relation = await _context.Relation.FindAsync(id);

            if (relation == null)
            {
                return NotFound();
            }

            return relation;
        }

        // PUT: api/Relations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelation(Guid id, Relation relation)
        {
            if (id != relation.Id)
            {
                return BadRequest();
            }

            _context.Entry(relation).State = EntityState.Modified;

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
        public async Task<ActionResult<Relation>> PostRelation(Relation relation)
        {
            relation.Id = Guid.NewGuid();
            relation.InvoiceDateGenerationOptions = 1;
            relation.InvoiceGroupByOptions = 1;
            relation.PaymentViaAutomaticDebit = false;
            relation.IsMe = false;
            relation.IsTemporary = false;
            relation.IsDisabled = false;
            relation.CreatedAt = DateTime.Now;
            relation.CreatedBy = "Admin";


            _context.Relation.Add(relation);
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
            var tblRelation = await _context.Relation.FindAsync(id);
            if (tblRelation == null)
            {
                return NotFound();
            }

            tblRelation.IsDisabled = true;

            //_context.TblRelation.Remove(tblRelation);
            await _context.SaveChangesAsync();

            return tblRelation;
        }

        private bool RelationExists(Guid id)
        {
            return _context.Relation.Any(e => e.Id == id);
        }
    }
}
