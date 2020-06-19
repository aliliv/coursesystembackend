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
    public class StudentFilesTypeManager : IStudentFilesTypeService
    {
        private IStudentFilesTypeDal _studentFilesType;
        public StudentFilesTypeManager(IStudentFilesTypeDal studentFilesTypeDal)
        {
            _studentFilesType = studentFilesTypeDal;
        }

        public IDataResult<List<StudentFilesType>> GetList()
        {
            return new SuccessDataResult<List<StudentFilesType>>(_studentFilesType.GetList().ToList());
        }
    }
}
