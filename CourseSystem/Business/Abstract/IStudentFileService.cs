using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IStudentFileService
    {
        IResult Add(StudentFile studentFile);
        IDataResult<List<StudentFileDto>> GetList(int userid);
        IResult Delete(StudentFile studentFile);
    }
}
