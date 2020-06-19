using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dtos;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Microsoft.Extensions.Hosting;
using System.IO;
using Entities.Concrete;

namespace WebApi.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IHostEnvironment _hostEnvironment;
        private IUserBranchService _userBranchService;
      
        public AuthController(IAuthService authService,IHostEnvironment hostEnvironment,IUserBranchService userBranchService)
        {
            _authService = authService;
            _hostEnvironment = hostEnvironment;
            _userBranchService = userBranchService;
        }
        [HttpPost(template: "login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost(template: "register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            //if (userForRegisterDto.Base64Image != null && userForRegisterDto.Base64Image != "")
            //{
            //    string path = _hostEnvironment.ContentRootPath + "/UserImage";
            //    Guid imageguidname = Guid.NewGuid();
            //    string imageName = imageguidname.ToString() + ".jpg";
            //    string imgPath = Path.Combine(path, imageName);
            //    byte[] imageBytes = Convert.FromBase64String(userForRegisterDto.Base64Image.Split(',')[1]);
            //    using (var imageFile = new FileStream(imgPath, FileMode.Create))
            //    {
            //        imageFile.Write(imageBytes, 0, imageBytes.Length);
            //        imageFile.Flush();
            //    }
            //    userForRegisterDto.ImageName = imageName;
            //}
            //var message = new MimeMessage();
            //message.From.Add(new MailboxAddress("Course System", "m.aliliv53@gmail.com"));
            //message.To.Add(new MailboxAddress("User", userForRegisterDto.Email));
            //message.Subject = "User Password";
            //Guid g = Guid.NewGuid();
            //message.Body = new TextPart("plain")
            //{
            //    Text = "Your Password= "+ g.ToString()
            //};

            //using (var client=new SmtpClient())
            //{
            //    client.Connect("smtp.gmail.com", 587, false);
            //    client.Authenticate("m.aliliv53@gmail.com", "1642453.");
            //    client.Send(message);
            //    client.Disconnect(true);
            //}
            //userForRegisterDto.Password = g.ToString();
            userForRegisterDto.Password = "1234";
            var registerResult = _authService.Register(userForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                foreach (var item in userForRegisterDto.Branchs)
                {
                    UserBranch userBranch = new UserBranch();
                    userBranch.BranchId = item.Id;
                    userBranch.UserId = registerResult.Data.Id;
                    _userBranchService.Add(userBranch);
                }
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
    }
}
