using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using WebAPI.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Domain.ViewModels.Relation;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IRelationsService _relationsService;

        /// <summary>
        /// 
        /// </summary>
        public PageController(IRelationsService relationsService)
        {
            _relationsService = relationsService;
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="orderByDescending"></param>
        /// <param name="filterBy"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{pageNumber}/{pageSize}/{sortBy}/{orderByDescending}/{filterBy}")]
        public async Task<IActionResult> Get(int pageNumber, int pageSize, string sortBy, bool orderByDescending, string filterBy)
        {
            // todo: use middleware to  handle exceptions
            try
            {   
                var relations = await _relationsService.GetRelations(pageNumber, pageSize, sortBy, orderByDescending, filterBy);
                
                return Ok(relations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}" );
            }

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RelationDetailsViewModel>> GetRelation(Guid id)
        {
            var relation = await _relationsService.GetRelationsById(id);

            if (relation == null)
            {
                return NotFound();
            }

            return relation;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelation(Guid id, RelationDetailsEditModel relationModel)
        {
            var relation = await _relationsService.EditModel(id, relationModel);

            if (id != relation.Id)
            {
                return BadRequest();
            }

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

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<RelationDetailsCreateModel>> PostRelation(RelationDetailsCreateModel relationModel)
        {

            var relation = await _relationsService.CreateModel(relationModel);

            return CreatedAtAction("GetRelation", new { id = relation.Id }, relation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Relation>> DeleteRelation(Guid id)
        {
            var relation = await _relationsService.DeleteModel(id);

            if (relation == null)
            {
                return NotFound();
            }

            #region Implemented Soft Delete
            relation.IsDisabled = true;


            //_context.TblRelation.Remove(tblRelation);
            #endregion

            return relation;
        }

        //private bool RelationExists(Guid id)
        //{
        //    return _context.Relations.Any(e => e.Id == id);
        //}
    }
}
