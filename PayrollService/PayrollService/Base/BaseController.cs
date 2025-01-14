using Command.Message;
using Microsoft.AspNetCore.Mvc;
using Payroll.BL.Department;
using PayrollService.Controllers;

namespace PayrollService.Base
{
    public abstract class BaseController : ControllerBase
    {
        public readonly ILogger<EmployeeController> _logger;

        public BaseController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }
    }
}
