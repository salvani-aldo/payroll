using Command.Query.Status;
using Microsoft.AspNetCore.Mvc;
using PayrollServiceV2.Base;
using PayrollServiceV2.Model;
using Service.BL._Interface;

namespace PayrollServiceV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : BaseController
    {
        private readonly IStatusBL _statusBL;
        public StatusController(IStatusBL statusBL)
        {
            _statusBL = statusBL;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StatusGetModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get()
        {
            var result = await _statusBL.Get();

            return Ok(result);
        }
    }
}
