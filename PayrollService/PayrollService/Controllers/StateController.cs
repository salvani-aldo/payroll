using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payroll.BL._Interfaces;
using Payroll.BL.State;

namespace PayrollService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateBL _stateBL;
        public StateController(ILogger<StateController> logger, IStateBL stateBL)
        {
            _stateBL = stateBL;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _stateBL.GetStates();

            return Ok(result);
        }
    }
}
