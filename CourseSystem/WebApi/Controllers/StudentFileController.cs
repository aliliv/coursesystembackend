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
    public class StudentFileController : ControllerBase
    {
        private IStudentFileService _studentFileService;
        public StudentFileController(IStudentFileService studentFileService)
        {
            _studentFileService = studentFileService;
        }
        [HttpPost(template: "add")]
        public IActionResult Add(StudentFile studentFile)
        {
            var result = _studentFileService.Add(studentFile);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet(template: "getallbyuserid")]
        public IActionResult GetList(int userid)
        {
            var result = _studentFileService.GetList(userid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "delete")]
        public IActionResult Delete(StudentFile studentFile)
        {
            var result = _studentFileService.Delete(studentFile);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
    }
}