using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class EvaluationManager : IEvaluationService
    {
        private IEvaluationDal _evaluationDal;
        public EvaluationManager(IEvaluationDal evaluationDal)
        {
            _evaluationDal = evaluationDal;
        }
        public IDataResult<Evaluation> Add(Evaluation evaluation)
        {
            return new SuccessDataResult<Evaluation>(_evaluationDal.AddReturnEntity(evaluation),Messages.EvaluationAdded);
        }

        public IDataResult<Evaluation> GetById(int evaluationid)
        {
            return new SuccessDataResult<Evaluation>(_evaluationDal.Get(filter: e => e.Id == evaluationid));
        }

        public IDataResult<List<Evaluation>> GetList()
        {
            return new SuccessDataResult<List<Evaluation>>(_evaluationDal.GetList().ToList());
        }



        public IResult Update(Evaluation evaluation)
        {
            _evaluationDal.Update(evaluation);
            return new SuccessResult(Messages.EvaluationUpdate);
        }

       public IDataResult<ReturnEvaluationSearchDto> GetListByFilter(EvaluationSearchDto evaluationSearchDto)
        {
            return new SuccessDataResult<ReturnEvaluationSearchDto>(_evaluationDal.GetListTableView(evaluationSearchDto));
        }

    
    }
}
