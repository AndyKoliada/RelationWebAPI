using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Domain.ViewModels.Relation;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Main API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IRelationsService _relationsService;

        /// <summary>
        /// DI constructor
        /// </summary>
        public PageController(IRelationsService relationsService)
        {
            _relationsService = relationsService;
        }
 
        /// <summary>
        /// Get method using URI arguments for composing query.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortBy"></param>
        /// <param name="orderByDescending"></param>
        /// <param name="filterBy"></param>
        /// <returns>Only requested models</returns>
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

        /// <summary>
        /// Gets only models with provided id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Saves edited model to dbContext by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="relationModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelation(Guid id, RelationDetailsEditModel relationModel)
        {
            var relation = await _relationsService.EditModel(id, relationModel);

            if (id != relation.Id)
            {
                return BadRequest();
            }

            return NoContent();
        }
        /// <summary>
        /// Creates new model in dbContext.
        /// </summary>
        /// <param name="relationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<RelationDetailsCreateModel>> PostRelation(RelationDetailsCreateModel relationModel)
        {
            var relation = await _relationsService.CreateModel(relationModel);

            return CreatedAtAction("GetRelation", new { id = relation.Id }, relation);
        }
        /// <summary>
        /// Deletes model by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
    }
}
