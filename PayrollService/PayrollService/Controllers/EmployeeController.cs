using Command.Request.Handler.Employee.Post;
using Command.Request.Handler.Employee.Put;
using Microsoft.AspNetCore.Mvc;
using Payroll.BL._Interfaces;
using PayrollService.Base;

namespace PayrollService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeBL _employeeBL;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeBL employeeBL)
            : base(logger)
        {
            _employeeBL = employeeBL;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _employeeBL.GetEmployees();

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EmployeePutModel model)
        {
            var result = await _employeeBL.UpdateEmployee(model);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(EmployeePostModel model)
        {
            var result = await _employeeBL.SaveEmployee(model);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeBL.DeleteEmployee(id);

            return Ok();
        }
    }
}
