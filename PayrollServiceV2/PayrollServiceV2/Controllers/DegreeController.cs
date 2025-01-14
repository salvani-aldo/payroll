using Microsoft.AspNetCore.Mvc;
using PayrollServiceV2.Base;
using PayrollServiceV2.Model;
using Service.BL._Interface;

namespace PayrollServiceV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : BaseController
    {
        private readonly IDegreeBL _degreeBL;

        public DegreeController(ILogger<DepartmentController> logger, IDegreeBL degreeBL)
        {
            _degreeBL = degreeBL;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get()
        {
            var result = await _degreeBL.Get();

            return Ok(result);
        }
    }
}
