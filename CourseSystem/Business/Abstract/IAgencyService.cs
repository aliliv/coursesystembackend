using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.SearchTableView;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAgencyService
    {
        IResult Add(Agency agency);
        IDataResult<Agency> GetById(int agencyid);
        IDataResult<List<Agency>> GetList();
        IDataResult<ReturnAgencySearchDto> GetListByFilter(AgencySearchDto agencySearchDto);
        IResult Update(Agency agency);
    }
}
