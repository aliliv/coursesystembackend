using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private IStudentCourseService _studentCourseService;
        public StudentCourseController(IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
        }
        [HttpPost(template: "add")]
        public IActionResult Add(StudentCourse studentCourse)
        {

            var result = _studentCourseService.Add(studentCourse);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);

        }
    }
}