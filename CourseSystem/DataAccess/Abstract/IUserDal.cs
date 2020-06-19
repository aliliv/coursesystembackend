using Core.DataAccess;
using Core.Entities.Concrate;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        ReturnUserSearchDto GetListTableView(UserSearchDto userSearchDto);
        List<ActiveTaacherListDto> GetActiveTeacher();
    }
}
