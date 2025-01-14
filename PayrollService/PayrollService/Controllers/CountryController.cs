using Microsoft.AspNetCore.Mvc;
using Payroll.BL._Interfaces;

namespace PayrollService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryBL _countryBL;
        public CountryController(ILogger<CountryController> logger, ICountryBL countryBL)
        {
            _countryBL = countryBL;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _countryBL.GetCountries();

            return Ok(result);
        }
    }
}
