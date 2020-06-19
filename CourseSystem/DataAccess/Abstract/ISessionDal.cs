using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.SearchTableView;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   
    public interface ISessionDal: IEntityRepository<Session>
    {
        ReturnSessionSearchDto GetListTableView(SessionSearchDto sessionSearchDto);
        List<ActiveSessionListDto> GetActiveSessionList();
        List<ActiveSessionForBranchDto> GetActiveSessionForBranch(int branchid);
    }
}
