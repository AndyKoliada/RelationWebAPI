using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Domain.ViewModels.Relation;
using WebAPI.Domain.Interfaces.Services;
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
        private readonly ILoggerService _logger;

        /// <summary>
        /// DI constructor
        /// </summary>
        public RelationsController(IRelationsService relationsService, ILoggerService logger)
        {
            _relationsService = relationsService;
            _logger = logger;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QueryParameters queryParameters)
        {
            // todo: use middleware to  handle exceptions
            try
            {
                _logger.LogDebug($"Trying to get relations with queryParameters: {queryParameters}");

                var relations = await _relationsService.GetRelations(queryParameters);

                return Ok(relations);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in get relations: {ex.Message}");

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
            try
            {
                _logger.LogDebug($"Trying to get relation by id: {id}");

                var relation = await _relationsService.GetRelationsById(id);

                if (relation == null)
                {
                    return NotFound();
                }

                return relation;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception in get by id: {ex.Message}");

                return StatusCode(500, ex.Message);
            }
            
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
            try
            {
                await _relationsService.DeleteModel(ids);

                return StatusCode(204);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
