using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEvaluationAssessmentService
    {
        IDataResult<EvaluationAssessment> Add(EvaluationAssessment evaluationAssessment);
        IDataResult<List<EvaluationAssessment>> GetListByEvaluationId(int evaluationid);
        IResult Delete(EvaluationAssessment evaluationAssessment);
    }
}
