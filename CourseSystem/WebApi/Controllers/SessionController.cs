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
    public class SessionController : ControllerBase
    {
        private ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        [HttpGet(template: "getbyid")]
        public IActionResult GetById(int sessionid)
        {
            var result = _sessionService.GetById(sessionid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet(template: "getactive")]
        public IActionResult GetActive()
        {
            var result = _sessionService.GetActiveSessionList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet(template: "getactiveforbranch")]
        public IActionResult GetActiveForBranch(int branchid)
        {
            var result = _sessionService.GetActiveSessionForBranchList(branchid);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "add")]
        public IActionResult Add(SessionDto sessionDto)
        {
            Session session = new Session();
            session.Branch = sessionDto.Branch;
            session.Course = sessionDto.Course;
            session.EndDate = Convert.ToDateTime(sessionDto.EndDate).Date;
            session.Evaluation = sessionDto.Evaluation;
            session.Friday = sessionDto.Friday;
            session.Id = sessionDto.Id;
            session.Monday = sessionDto.Monday;
            session.StartDate = Convert.ToDateTime(sessionDto.StartDate).Date;
            session.Status = sessionDto.Status;
            session.Thursday = sessionDto.Thursday;
            session.Tuesday = sessionDto.Tuesday;
            session.Tuition = sessionDto.Tuition;
            session.Wednesday = sessionDto.Wednesday;


            if (session.Id == 0)
            {
                var result = _sessionService.Add(session);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                    return BadRequest(result.Message);
            }
            else
            {
                var result = _sessionService.Update(session);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                    return BadRequest(result.Message);
            }

        }
        [HttpPost(template: "getsearch")]
        public IActionResult GetSearch(SessionSearchDto sessionSearchDto)
        {
            var result = _sessionService.GetListByFilter(sessionSearchDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
    }

}