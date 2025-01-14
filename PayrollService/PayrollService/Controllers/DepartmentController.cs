using Command.Request.Handler.Department.Post;
using Command.Request.Handler.Department.Put;
using Microsoft.AspNetCore.Mvc;
using Payroll.BL._Interfaces;
using PayrollService.Base;

namespace PayrollService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentBL _departmentBL;
        public DepartmentController(ILogger<EmployeeController> logger, IDepartmentBL departmentBL)
            : base(logger)
        {
            _departmentBL = departmentBL;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _departmentBL.GetDeparments();

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(DepartmentPutModel model)
        {
            var result = await _departmentBL.UpdateDeparment(model);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(DepartmentPostModel model)
        {
            var result = await _departmentBL.SaveDeparment(model);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _departmentBL.DeleteDeparment(id);

            return Ok();
        }
    }
}
