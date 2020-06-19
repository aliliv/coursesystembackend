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
    public class AssignmentController : ControllerBase
    {
        private IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        [HttpPost(template: "getsearch")]
        public IActionResult GetSearch(AssignmentSearchDto assignmentSearchDto)
        {
            var result = _assignmentService.GetListByFilter(assignmentSearchDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "add")]
        public IActionResult Add(Assignment assignment)
        {
            if (assignment.Id == 0)
            {
                var result = _assignmentService.Add(assignment);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                    return BadRequest(result.Message);
            }
            else
            {
                var result = _assignmentService.Update(assignment);
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