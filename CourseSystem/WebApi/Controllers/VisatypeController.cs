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
    public class VisatypeController : ControllerBase
    {
        private IVisatypeService _visatypeService;
        public VisatypeController(IVisatypeService visatypeService)
        {
            _visatypeService = visatypeService;
        }
        [HttpGet(template: "getall")]

        public IActionResult GetList()
        {
            var result = _visatypeService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
    }
}