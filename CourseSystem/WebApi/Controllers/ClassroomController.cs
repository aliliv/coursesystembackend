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
    public class ClassroomController : ControllerBase
    {
        private IClassroomService _classroomService;
        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }
        [HttpPost(template: "add")]
        public IActionResult Add(Classroom classroom)
        {
            if (classroom.Id == 0)
            {
                var result = _classroomService.Add(classroom);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                    return BadRequest(result.Message);
            }
            else
            {
                var result = _classroomService.Update(classroom);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                    return BadRequest(result.Message);
            }

        }
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _classroomService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpGet(template: "getbyid")]
        public IActionResult GetById(int classroomid)
        {
            var result = _classroomService.GetById(classroomid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet(template: "getactivelist")]
        public IActionResult GetActiveList()
        {
            var result = _classroomService.GetActiveClassList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpPost(template: "getsearch")]
        public IActionResult GetSearch(ClassroomSearchDto classroomSearchDto)
        {
            var result = _classroomService.GetListByFilter(classroomSearchDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

    }
}