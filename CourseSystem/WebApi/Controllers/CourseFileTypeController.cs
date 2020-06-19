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
    public class CourseFileTypeController : ControllerBase
    {
        private ICourseFileTypeService _courseFileTypeService;
        public CourseFileTypeController(ICourseFileTypeService courseFileTypeService)
        {
            _courseFileTypeService = courseFileTypeService;
        }
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _courseFileTypeService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
    }
}