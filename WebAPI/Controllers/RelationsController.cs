using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Domain.ViewModels.Relation;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Models;
using WebAPI.Domain.Queries;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Main API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RelationsController : ControllerBase
    {
        private readonly IRelationsService _relationsService;

        /// <summary>
        /// DI constructor
        /// </summary>
        public RelationsController(IRelationsService relationsService)
        {
            _relationsService = relationsService;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QueryParameters queryParameters)
        {
            // todo: use middleware to  handle exceptions
            try
            {   
                var relations = await _relationsService.GetRelations(queryParameters);
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
                //return BadRequest();
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
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteRelation([FromQuery]params Guid[] ids)
        {
            var relation = await _relationsService.DeleteModel(ids);

            return StatusCode(200);
        }
    }
}
