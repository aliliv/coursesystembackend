using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEvaluationService
    {
        
        IDataResult<Evaluation> GetById(int evaluationid);
        IResult Update(Evaluation evaluation);
        IDataResult<ReturnEvaluationSearchDto> GetListByFilter(EvaluationSearchDto evaluationSearchDto);
        IDataResult<List<Evaluation>> GetList();
        IDataResult<Evaluation> Add(Evaluation evaluation);
    }
}
