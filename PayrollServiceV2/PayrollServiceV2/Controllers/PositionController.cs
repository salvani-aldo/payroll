using Command.Query.Position;
using Command.Request.Position.Delete;
using Command.Request.Position.Post.Model;
using Command.Request.Position.Put.Model;
using Microsoft.AspNetCore.Mvc;
using PayrollServiceV2.Base;
using PayrollServiceV2.Model;
using Service.BL._Interface;

namespace PayrollServiceV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : BaseController
    {
        private readonly IPositionBL _positionBL;
        private readonly ILogger<PositionController> _logger;

        public PositionController(ILogger<PositionController> logger, IPositionBL positionBL)
        {
            _positionBL = positionBL;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PositionGetModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get()
        {

            var result = await _positionBL.Get();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<PositionDeleteModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _positionBL.Delete(id);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]

        [ProducesResponseType(typeof(PositionPostRequestModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(PositionPostCommandModel model)
        {
            var result = await _positionBL.Save(model);

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PositionPutRequestModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(PositionPutCommandModel model)
        {
            var result = await _positionBL.Update(model);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
