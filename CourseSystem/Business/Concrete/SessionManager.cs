using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.SearchTableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class SessionManager : ISessionService
    {
        private ISessionDal _sessionDal;
        public SessionManager(ISessionDal sessionDal)
        {
            _sessionDal = sessionDal;
        }
        public IResult Add(Session sesion)
        {
            _sessionDal.Add(sesion);
            return new SuccessResult(Messages.SessionAdded);
        }

        public IDataResult<List<ActiveSessionForBranchDto>> GetActiveSessionForBranchList(int branchid)
        {
            return new SuccessDataResult<List<ActiveSessionForBranchDto>>(_sessionDal.GetActiveSessionForBranch(branchid));
        }

        public IDataResult<List<ActiveSessionListDto>> GetActiveSessionList()
        {
            return new SuccessDataResult<List<ActiveSessionListDto>>(_sessionDal.GetActiveSessionList());
        }


        public IDataResult<Session> GetById(int sessionid)
        {
            return new SuccessDataResult<Session>(_sessionDal.Get(filter: s => s.Id == sessionid));
        }

        public IDataResult<ReturnSessionSearchDto> GetListByFilter(SessionSearchDto sessionSearchDto)
        {
            return new SuccessDataResult<ReturnSessionSearchDto>(_sessionDal.GetListTableView(sessionSearchDto));
        }

        public IResult Update(Session session)
        {
            _sessionDal.Update(session);
            return new SuccessResult(Messages.SessionUpdate);
        }
    }
}
