using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrate;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public IDataResult<User> GetByMail(string email)
        {   
           return new SuccessDataResult<User>(_userDal.Get(filter: u => u.Email == email));
        }
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(filter: u => u.Id == id));
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList().ToList());
        }

        public IDataResult<ReturnUserSearchDto> GetListByFilter(UserSearchDto userSearchDto)
        {
            return new SuccessDataResult<ReturnUserSearchDto>(_userDal.GetListTableView(userSearchDto));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<ActiveTaacherListDto>> GetActiveTeacherList()
        {
            return new SuccessDataResult<List<ActiveTaacherListDto>>(_userDal.GetActiveTeacher());
        }
    }
}
