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
    public class EvaluationController : ControllerBase
    {
        private IEvaluationService _evaluationService;
        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }
        [HttpPost(template: "add")]
        public IActionResult Add(Evaluation evaluation)
        {
            if (evaluation.Id == 0)
            {
                var result = _evaluationService.Add(evaluation);
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                    return BadRequest(result.Message);
            }
            else
            {
                var result = _evaluationService.Update(evaluation);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                    return BadRequest(result.Message);
            }

        }
        [HttpGet(template: "getbyid")]
        public IActionResult GetById(int evaluationid)
        {
            var result = _evaluationService.GetById(evaluationid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "getsearch")]
        public IActionResult GetSearch(EvaluationSearchDto evaluationSearchDto)
        {
            var result = _evaluationService.GetListByFilter(evaluationSearchDto);
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
            var result = _evaluationService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
    }
}