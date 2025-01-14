using Command.Query.Gender;
using Microsoft.AspNetCore.Mvc;
using PayrollServiceV2.Base;
using PayrollServiceV2.Model;
using Service.BL._Interface;

namespace PayrollServiceV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : BaseController
    {
        private readonly IGenderBL _genderBL;
        public GenderController(IGenderBL genderBL)
        {
            _genderBL = genderBL;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GenderGetModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get()
        {
            var result = await _genderBL.Get();

            return Ok(result);
        }
    }
}
