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
    public class AssessmentController : ControllerBase
    {
        private IAssessmentService _assessmentService;
        public AssessmentController(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _assessmentService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
    }
}