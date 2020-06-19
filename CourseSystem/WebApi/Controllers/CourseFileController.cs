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
    public class CourseFileController : ControllerBase
    {
        private ICourseFileService _courseFileService;
        public CourseFileController(ICourseFileService courseFileService)
        {
            _courseFileService = courseFileService;
        }
        [HttpPost(template: "add")]
        public IActionResult Add(CourseFileDto courseFile)
        {
            foreach (var item in courseFile.CourseFiles)
            {
                item.CourseId = courseFile.CourseId;
                _courseFileService.Add(item);
            }
            return Ok("");
        }
        [HttpPost(template: "delete")]
        public IActionResult Delete(CourseFile courseFile)
        {
            var result = _courseFileService.Delete(courseFile);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet(template: "getbycourseid")]
        public IActionResult GetByCourseFiles(int courseid)
        {
            var result = _courseFileService.GetListByCourseId(courseid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

    }
    }