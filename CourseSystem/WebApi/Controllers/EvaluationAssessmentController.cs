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
    public class EvaluationAssessmentController : ControllerBase
    {
        private IEvaluationAssessmentService _evaluationAssessmentService;
        public EvaluationAssessmentController(IEvaluationAssessmentService evaluationAssessmentService)
        {
            _evaluationAssessmentService = evaluationAssessmentService;
        }
        [HttpPost(template: "add")]
        public IActionResult Add(EvaluationAssessment evaluationAssessment)
        {

            var result = _evaluationAssessmentService.Add(evaluationAssessment);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result.Message);


        }
        [HttpGet(template: "getListbyevaluationId")]
        public IActionResult GetByCategory(int evaluationAssessmentid)
        {
            var result = _evaluationAssessmentService.GetListByEvaluationId(evaluationAssessmentid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(EvaluationAssessment evaluationAssessment)
        {
            var result = _evaluationAssessmentService.Delete(evaluationAssessment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
    }
}