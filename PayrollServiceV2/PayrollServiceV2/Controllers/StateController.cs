using Command.Query.State;
using Microsoft.AspNetCore.Mvc;
using PayrollServiceV2.Base;
using PayrollServiceV2.Model;
using Service.BL._Interface;

namespace PayrollServiceV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : BaseController
    {
        private readonly ILogger<StateController> _logger;
        private readonly IStateBL _stateBL;
        public StateController(ILogger<StateController> logger, IStateBL stateBL)
        {
            _logger = logger;
            _stateBL = stateBL;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StateGetModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get()
        {
            var result = await _stateBL.GetStates();

            return Ok(result);
        }
    }
}
