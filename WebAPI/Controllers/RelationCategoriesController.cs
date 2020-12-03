using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ModelsConnected;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationCategoriesController : ControllerBase
    {
        private readonly TestDBContext _context;

        public RelationCategoriesController(TestDBContext context)
        {
            _context = context;
        }

        // GET: api/RelationCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelationCategory>>> GetRelationCategories()
        {
            return await _context.RelationCategories.ToListAsync();
        }

        // GET: api/RelationCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RelationCategory>> GetRelationCategory(Guid id)
        {
            var relationCategory = await _context.RelationCategories.FindAsync(id);

            if (relationCategory == null)
            {
                return NotFound();
            }

            return relationCategory;
        }

        // PUT: api/RelationCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelationCategory(Guid id, RelationCategory relationCategory)
        {
            if (id != relationCategory.RelationId)
            {
                return BadRequest();
            }

            _context.Entry(relationCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationCategoryExists(id))
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

        // POST: api/RelationCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RelationCategory>> PostRelationCategory(RelationCategory relationCategory)
        {
            _context.RelationCategories.Add(relationCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RelationCategoryExists(relationCategory.RelationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRelationCategory", new { id = relationCategory.RelationId }, relationCategory);
        }

        // DELETE: api/RelationCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RelationCategory>> DeleteRelationCategory(Guid id)
        {
            var relationCategory = await _context.RelationCategories.FindAsync(id);
            if (relationCategory == null)
            {
                return NotFound();
            }

            _context.RelationCategories.Remove(relationCategory);
            await _context.SaveChangesAsync();

            return relationCategory;
        }

        private bool RelationCategoryExists(Guid id)
        {
            return _context.RelationCategories.Any(e => e.RelationId == id);
        }
    }
}
