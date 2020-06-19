using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AssignmentManager: IAssignmentService
    {
        private IAssignmentDal _assignmentDal;
        public AssignmentManager(IAssignmentDal assignmentDal)
        {
            _assignmentDal = assignmentDal;
        }

        public IResult Add(Assignment assignment)
        {
            _assignmentDal.Add(assignment);
            return new SuccessResult(Messages.AssignmentAdded);
        }

        public IDataResult<ReturnAssignmentSearchDto> GetListByFilter(AssignmentSearchDto assignmentSearchDto)
        {
            return new SuccessDataResult<ReturnAssignmentSearchDto>(_assignmentDal.GetListTableView(assignmentSearchDto));
        }

        public IResult Update(Assignment assignment)
        {
            _assignmentDal.Update(assignment);
            return new SuccessResult(Messages.AssignmentUpdate);
        }
    }
}
