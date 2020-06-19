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
    public class AgencyManager : IAgencyService
    {
        private IAgencyDal _agencyDal;
        public AgencyManager(IAgencyDal agencyDal)
        {
            _agencyDal = agencyDal;
        }
        public IResult Add(Agency agency)
        {
            _agencyDal.Add(agency);
            return new SuccessResult(Messages.AgencyAdded);
        }

        public IDataResult<Agency> GetById(int agencyid)
        {
            return new SuccessDataResult<Agency>(_agencyDal.Get(filter: a => a.Id == agencyid));
        }

        public IDataResult<List<Agency>> GetList()
        {
            return new SuccessDataResult<List<Agency>>(_agencyDal.GetList().ToList());
        }

        public IDataResult<ReturnAgencySearchDto> GetListByFilter(AgencySearchDto agencySearchDto)
        {
            return new SuccessDataResult<ReturnAgencySearchDto>(_agencyDal.GetListTableView(agencySearchDto));
        }

        public IResult Update(Agency agency)
        {
            _agencyDal.Update(agency);
            return new SuccessResult(Messages.AgencyUpdate);
        }
    }
}
