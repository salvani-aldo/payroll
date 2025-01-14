using Microsoft.AspNetCore.Mvc;

namespace PayrollServiceV2.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError() => Problem();
    }
}
