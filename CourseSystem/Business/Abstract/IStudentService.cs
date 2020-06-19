using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IStudentService
    {
        IResult Add(Student student);
        IResult Update(Student student);
        IDataResult<Student> GetByUserId(int userid);
    }
}
