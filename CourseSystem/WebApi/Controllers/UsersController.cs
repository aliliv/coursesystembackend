using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrate;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private IHostEnvironment _hostEnvironment;
        private IUserBranchService _userBranchService;
        private IBranchService _branchService;

        public UsersController(IUserService userService, IMapper mapper, IHostEnvironment hostEnvironment,IUserBranchService userBranchService, IBranchService branchService)
        {
            _userService = userService;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            _userBranchService = userBranchService;
            _branchService = branchService;
        }

        [HttpGet(template: "getbyuseremail")]
        public IActionResult GetByUserEmail(string email)
        {
            var result = _userService.GetByMail(email);
      
            if (result.Success)
            {
                UserDto userDto = _mapper.Map<UserDto>(result.Data);
                userDto.operationClaims = _userService.GetClaims(result.Data);
                List<Branch> branches = new List<Branch>();
                List<UserBranch> userBranches= _userBranchService.GetListByUserId(result.Data.Id).Data.ToList();
                foreach (var item in userBranches)
                {
                    Branch branch = _branchService.GetByBranchId(item.BranchId);
                    branches.Add(branch);
                }
                userDto.userBranches = branches;
                return Ok(userDto);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "update")]
        public IActionResult Update(User user)
        {    
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet(template: "getbyuserid")]
        public IActionResult GetByUserId(int id)
        {
            var result = _userService.GetById(id);

            if (result.Success)
            {
                UserDto userDto = _mapper.Map<UserDto>(result.Data);
                // userDto.operationClaims = _userService.GetClaims(result.Data);
                List<Branch> branches = new List<Branch>();
                List<UserBranch> userBranches = _userBranchService.GetListByUserId(result.Data.Id).Data.ToList();
                foreach (var item in userBranches)
                {
                    Branch branch = _branchService.GetByBranchId(item.BranchId);
                    branches.Add(branch);
                }
                userDto.userBranches = branches;
                return Ok(userDto);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpPost(template: "getsearch")]
        public IActionResult GetSearch(UserSearchDto userSearchDto)
        {
            var result = _userService.GetListByFilter(userSearchDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
        [HttpGet(template: "getactiveteacherlist")]
        public IActionResult GetList()
        {
            var result = _userService.GetActiveTeacherList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
                return BadRequest(result.Message);
        }
    }
}