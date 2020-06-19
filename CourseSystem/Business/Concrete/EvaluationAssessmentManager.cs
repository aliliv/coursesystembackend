using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class EvaluationAssessmentManager : IEvaluationAssessmentService
    {
        private IEvaluationAssessmentDal _evaluationAssessmentDal;
        public EvaluationAssessmentManager(IEvaluationAssessmentDal evaluationAssessmentDal)
        {
            _evaluationAssessmentDal = evaluationAssessmentDal;
        }
        public IDataResult<EvaluationAssessment> Add(EvaluationAssessment evaluationAssessment)
        {

            return new SuccessDataResult<EvaluationAssessment>(_evaluationAssessmentDal.AddReturnEntity(evaluationAssessment), Messages.EvaluationAssessmentAdded);
        }

        public IResult Delete(EvaluationAssessment evaluationAssessment)
        {
            _evaluationAssessmentDal.Delete(evaluationAssessment);
            return new SuccessResult(Messages.EvaluationAssessmentDeleted);
        }

        public IDataResult<List<EvaluationAssessment>> GetListByEvaluationId(int evaluationid)
        {
            return new SuccessDataResult<List<EvaluationAssessment>>(_evaluationAssessmentDal.GetList(filter: p => p.EvaluationId == evaluationid).ToList());
        }
    }
}
