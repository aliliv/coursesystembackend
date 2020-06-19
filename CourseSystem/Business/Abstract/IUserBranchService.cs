using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserBranchService
    {
        IResult Add(UserBranch userBranch);
        IDataResult<List<UserBranch>> GetList();
        IDataResult<List<UserBranch>> GetListByUserId(int UserId);
    }
}
