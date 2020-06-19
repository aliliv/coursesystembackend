﻿using System;
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
    public class StudentFilesTypeController : ControllerBase
    {
        private IStudentFilesTypeService _studentFilesTypeService;
        public StudentFilesTypeController(IStudentFilesTypeService studentFilesTypeService)
        {
            _studentFilesTypeService = studentFilesTypeService;
        }
        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _studentFilesTypeService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
    }
}