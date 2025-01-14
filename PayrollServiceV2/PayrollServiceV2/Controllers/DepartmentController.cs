using Command.Query.Department;
using Command.Request.Department.Post.Model;
using Command.Request.Department.Put.Model;
using Microsoft.AspNetCore.Mvc;
using PayrollServiceV2.Base;
using PayrollServiceV2.Model;
using Service.BL._Interface;

namespace PayrollServiceV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentBL _departmentBL;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentBL departmentBL)
        {
            _logger = logger;
            _departmentBL = departmentBL;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentGetModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get()
        {
            var result = await _departmentBL.Get();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<DepartmentPostQueryModel>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(DepartmentPostCommandModel model)
        {
            var result = await _departmentBL.Save(model);

            return new ObjectResult(result)
            {
                StatusCode = 201
            };
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _departmentBL.Delete(id);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(id);
        }

        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<DepartmentPutQueryModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(DepartmentPutCommandModel model)
        {
            var queryResult = await _departmentBL.Update(model);

            if (queryResult.Count() == 0)
            {
                return NotFound();
            }

            return Ok(queryResult);
        }
    }
}
