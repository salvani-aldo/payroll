using Microsoft.AspNetCore.Mvc;
using PayrollServiceV2.Base;

namespace PayrollServiceV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : BaseController
    {
        public CertificateController()
        {
        }

        [HttpGet]
        public ActionResult Get()
        {


            return Ok();
        }

        [HttpPost]
        public ActionResult Post()
        {
            return Ok();
        }
    }
}
