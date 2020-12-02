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

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly TestDBContext _context;

        public RelationsController(TestDBContext context, IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }

        //public async Task<ViewResult> Index(Index.Query query)
        // => View(await _mediator.Send(query));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Relation>>> GetRelation()
        {
            return await _context.Relations.Where(a => a.IsDisabled == false).ToListAsync();
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
        public async Task<IActionResult> PutRelation(Guid id, Relation relation)
        {
            RequiredFieldsInit.InitializeRequiredFields(relation);

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
            RequiredFieldsInit.InitializeRequiredFields(relation);

            

            _context.Relations.Add(relation);
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

            relation.IsDisabled = true;

            //_context.TblRelation.Remove(tblRelation);
            await _context.SaveChangesAsync();

            return relation;
        }

        private bool RelationExists(Guid id)
        {
            return _context.Relations.Any(e => e.Id == id);
        }
    }
}
