using Core.Entities.Concrate;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Dtos.ReturnSearchDto;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<User> GetById(int id);
        IDataResult<List<User>> GetList();
        IDataResult<List<ActiveTaacherListDto>> GetActiveTeacherList();
        IDataResult<ReturnUserSearchDto> GetListByFilter(UserSearchDto userSearchDto);
        IResult Update(User user);

    }
}
