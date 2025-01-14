using Command.Request.Emplooyee.Delete;
using Command.Request.Emplooyee.Post.Model;
using Microsoft.AspNetCore.Mvc;
using PayrollServiceV2.Base;
using PayrollServiceV2.Model;
using Service.BL._Interface;
using Service.BL.Employee.Model;

namespace PayrollServiceV2.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeBL _employeeBL;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeBL employeeBL)
        {
            _employeeBL = employeeBL;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeeQueryModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get()
        {
            var result = await _employeeBL.Get();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<EmployeePostQueryModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(EmployeeCommandModel model)
        {
            var result = await _employeeBL.Save(model);

            return new ObjectResult(result)
            {
                StatusCode = 201
            };
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeDeleteModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _employeeBL.Delete(id);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<EmployeePutCommandModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(EmployeePutCommandModel model)
        {
            var result = await _employeeBL.Update(model);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
    }

}
