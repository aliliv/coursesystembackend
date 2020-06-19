using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class StudentFileManager : IStudentFileService
    {
        private IStudentFileDal _studentFileDal;
        public StudentFileManager(IStudentFileDal studentFileDal)
        {
            _studentFileDal = studentFileDal;
        }

        public IResult Add(StudentFile studentFile)
        {
            _studentFileDal.Add(studentFile);
            return new SuccessResult(Messages.FileAdded);
        }

        public IDataResult<List<StudentFileDto>> GetList(int userid)
        {
           return new SuccessDataResult<List<StudentFileDto>>(_studentFileDal.GetStudentFile(userid));
        }

        public IResult Delete(StudentFile studentFile)
        {
            _studentFileDal.Delete(studentFile);
            return new SuccessResult(Messages.StudentFileDelete);
        }
    }
}
