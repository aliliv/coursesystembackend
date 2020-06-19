using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISessionService
    {
        IDataResult<Session> GetById(int sessionid);
        IResult Add(Session sesion);
        IDataResult<ReturnSessionSearchDto> GetListByFilter(SessionSearchDto sessionSearchDto);

        IDataResult<List<ActiveSessionForBranchDto>> GetActiveSessionForBranchList(int branchid);
        IDataResult<List<ActiveSessionListDto>> GetActiveSessionList();
        IResult Update(Session session);
    }
}
