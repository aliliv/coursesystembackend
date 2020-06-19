using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserBranchManager : IUserBranchService
    {
        private IUserBranchDal _userBranchDal;
        public UserBranchManager(IUserBranchDal userBranchDal)
        {
            _userBranchDal = userBranchDal;
        }
        public IResult Add(UserBranch userBranch)
        {
            _userBranchDal.Add(userBranch);
            return new SuccessResult(Messages.UserBranchAdded);
        }
        public IDataResult<List<UserBranch>> GetList()
        {
            return new SuccessDataResult<List<UserBranch>>(_userBranchDal.GetList().ToList());
        }

        public IDataResult<List<UserBranch>> GetListByUserId(int UserId)
        {
            return new SuccessDataResult<List<UserBranch>>(_userBranchDal.GetList(filter: p => p.UserId == UserId).ToList());
        }
    }
}
