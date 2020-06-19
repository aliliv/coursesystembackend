using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private IAgencyService _agencyService;
        public AgencyController(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _agencyService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "getsearch")]
        public IActionResult GetSearch(AgencySearchDto agencySearch)
        {
            var result = _agencyService.GetListByFilter(agencySearch);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet(template: "getbyid")]
        public IActionResult GetById(int agencyid)
        {
            var result = _agencyService.GetById(agencyid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "add")]
        public IActionResult Add(Agency agency)
        {
            if (agency.Id == 0)
            {
                var result = _agencyService.Add(agency);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                    return BadRequest(result.Message);
            }
            else
            {
                var result = _agencyService.Update(agency);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                    return BadRequest(result.Message);
            }
        }
    }
}