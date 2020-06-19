using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class AssessmentManager : IAssessmentService
    {
        private IAssessmentDal _assessmentDal;
        public AssessmentManager(IAssessmentDal assessmentDal)
        {
            _assessmentDal = assessmentDal;
        }
 
        public IDataResult<List<Assessment>> GetList()
        {
            return new SuccessDataResult<List<Assessment>>(_assessmentDal.GetList().ToList());
        }
    }
}
