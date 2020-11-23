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
    public class ViewRelationsController : ControllerBase
    {
        private readonly TestContext _context;

        public ViewRelationsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/ViewRelations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewRelation>>> GetViewRelation()
        {
            return await _context.ViewRelation.ToListAsync();
        }

        // GET: api/ViewRelations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewRelation>> GetViewRelation(Guid id)
        {
            var viewRelation = await _context.ViewRelation.FindAsync(id);

            if (viewRelation == null)
            {
                return NotFound();
            }

            return viewRelation;
        }

        // PUT: api/ViewRelations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViewRelation(Guid id, ViewRelation viewRelation)
        {
            if (id != viewRelation.Id)
            {
                return BadRequest();
            }

            _context.Entry(viewRelation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewRelationExists(id))
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

        // POST: api/ViewRelations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ViewRelation>> PostViewRelation(ViewRelation viewRelation)
        {
            _context.ViewRelation.Add(viewRelation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViewRelation", new { id = viewRelation.Id }, viewRelation);
        }

        // DELETE: api/ViewRelations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ViewRelation>> DeleteViewRelation(Guid id)
        {
            var viewRelation = await _context.ViewRelation.FindAsync(id);
            if (viewRelation == null)
            {
                return NotFound();
            }

            _context.ViewRelation.Remove(viewRelation);
            await _context.SaveChangesAsync();

            return viewRelation;
        }

        private bool ViewRelationExists(Guid id)
        {
            return _context.ViewRelation.Any(e => e.Id == id);
        }
    }
}
