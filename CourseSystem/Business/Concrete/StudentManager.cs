using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public IResult Add(Student student)
        {
            _studentDal.Add(student);
            return new SuccessResult(Messages.StudentAdded);
        }

        public IDataResult<Student> GetByUserId(int userid)
        {
            var result = _studentDal.Get(filter: s => s.UserId == userid);
            if (result == null)
                return new SuccessDataResult<Student>("0");
            else
                return new SuccessDataResult<Student>(result);
        }

        public IResult Update(Student student)
        {
            _studentDal.Update(student);
            return new SuccessResult(Messages.StudentUpdate);
        }
    }
}
