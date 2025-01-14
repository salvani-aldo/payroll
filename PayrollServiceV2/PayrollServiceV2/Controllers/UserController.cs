using Command.Query.User.GetById.Model;
using Microsoft.AspNetCore.Mvc;
using PayrollServiceV2.Base;
using PayrollServiceV2.Model;
using Service.BL._Interface;

namespace PayrollServiceV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly ILogger<StateController> _logger;
        private readonly IUserBL _userBL;
        public UserController(ILogger<StateController> logger, IUserBL userBL)
        {
            _logger = logger;
            _userBL = userBL;
        }

        /// <summary>
        /// user name (required)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet("{user?}")]
        [ProducesResponseType(typeof(IEnumerable<UserGetByNameQueryModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get(string user = "")
        {
            var model = await _userBL.GetUser(user);

            return Ok(model);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserGetByNameQueryModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get()
        {
            var model = await _userBL.GetUser("");

            //return StatusCode(StatusCodes.Status201Created, model);
            //return NoContent();

            return Ok(model);
        }
    }
}
