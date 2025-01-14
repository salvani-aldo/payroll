using Command.Request.Handler.Position.Post;
using Command.Request.Handler.Position.Put;
using Microsoft.AspNetCore.Mvc;
using Payroll.BL._Interfaces;
using PayrollService.Base;

namespace PayrollService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : BaseController
    {
        private readonly IPositionBL _positionBL;
        public PositionController(ILogger<EmployeeController> logger, IPositionBL position) : base(logger)
        {
            _positionBL = position;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _positionBL.GetPositions();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PositionPostModel model)
        {
            var result = await _positionBL.SavePosition(model);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(PositionPutModel model)
        {
            var result = await _positionBL.UpdatePosition(model);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _positionBL.DeletePosition(id);

            return Ok();
        }
    }
}
