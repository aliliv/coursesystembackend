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
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpPost(template: "add")]
        public IActionResult Add(Course course)
        {
            if (course.Id == 0)
            {
                var result = _courseService.Add(course);
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                    return BadRequest(result.Message);
            }
            else
            {
                var result = _courseService.Update(course);
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                    return BadRequest(result.Message);
            }

        }
        [HttpPost(template: "getsearch")]
        public IActionResult GetSearch(CourseSearchDto courseSearchDto)
        {
            var result = _courseService.GetListByFilter(courseSearchDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpGet(template: "getbyid")]
        public IActionResult GetById(int courseid)
        {
            var result = _courseService.GetById(courseid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet(template: "getall")]

        public IActionResult GetList()
        {
            var result = _courseService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

    }
}