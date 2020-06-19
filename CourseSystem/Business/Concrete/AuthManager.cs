using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrate;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper; 
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
             var claims=_userService.GetClaims(user);
             var accessToken=_tokenHelper.CreateToken(user,claims);
             return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);

        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessFullLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            DateTime dt=Convert.ToDateTime(userForRegisterDto.BirthDay);
            //DateTime.TryParseExact(userForRegisterDto.BirthDay,
            //           "MM-dd-yyyy",
            //           CultureInfo.InvariantCulture,
            //           DateTimeStyles.None,
            //           out dt);
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                ImageName = userForRegisterDto.ImageName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleId = userForRegisterDto.RoleId,
                Address=userForRegisterDto.Address,
                Phone1=userForRegisterDto.Phone1,
                Phone2=userForRegisterDto.Phone2,
                BirthDay= dt,
                Status=true,
                InstitutionId=userForRegisterDto.InstitutionId,
                Gender=userForRegisterDto.Gender,
                CountryId=userForRegisterDto.CountryId,
                SSNPassport=userForRegisterDto.SSNPassport

            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
