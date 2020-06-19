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
    public class CourseFileTypeManager : ICourseFileTypeService
    {
        private ICourseFileTypeDal _courseFileType;
        public CourseFileTypeManager(ICourseFileTypeDal courseFileTypeDal)
        {
            _courseFileType = courseFileTypeDal;
        }

        public IDataResult<List<CourseFileType>> GetList()
        {
            return new SuccessDataResult<List<CourseFileType>>(_courseFileType.GetList().ToList());
        }
    }
}
