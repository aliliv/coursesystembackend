using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _countryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
    }
}