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
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost(template: "add")]
        public IActionResult Add(Student student)
        {
            if (student.Id == 0)
            {
                var result = _studentService.Add(student);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                    return BadRequest(result.Message);
            }
            else
            {
                var result = _studentService.Update(student);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                    return BadRequest(result.Message);
            }

        }
        [HttpGet(template: "getbyuserid")]
        public IActionResult GetByUserId(int userid)
        {
            var result = _studentService.GetByUserId(userid);

            if (result.Success)
            {
        
                return Ok(result);
            }
            else
                return BadRequest(result.Message);
        }
    }
}