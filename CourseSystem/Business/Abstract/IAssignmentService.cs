using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAssignmentService
    {
        IResult Add(Assignment assignment);
        IResult Update(Assignment assignment);
        IDataResult<ReturnAssignmentSearchDto> GetListByFilter(AssignmentSearchDto assignmentSearchDto);
    }
}
