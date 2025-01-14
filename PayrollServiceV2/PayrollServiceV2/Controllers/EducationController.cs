using Command.Query.Education;
using Microsoft.AspNetCore.Mvc;
using PayrollServiceV2.Base;
using PayrollServiceV2.Model;
using Service.BL._Interface;

namespace PayrollServiceV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : BaseController
    {
        IEducationBL _educationBL;
        public EducationController(ILogger<EducationController> logger, IEducationBL educationBL)
        {
            _educationBL = educationBL;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EducationGetModel>>> Get()
        {
            var result = await _educationBL.Get();

            return Ok(result);
        }
    }
}
