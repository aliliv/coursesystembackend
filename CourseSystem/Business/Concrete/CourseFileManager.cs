using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CourseFileManager:ICourseFileService
    {
        private ICourseFileDal _courseFileDal;
        public CourseFileManager(ICourseFileDal courseFileDal)
        {
            _courseFileDal = courseFileDal;
        }

        public void Add(CourseFile courseFile)
        {
            _courseFileDal.Add(courseFile);
        }

        public IResult Delete(CourseFile courseFile)
        {
            _courseFileDal.Delete(courseFile);
            return new SuccessResult(Messages.CourseFileDelete);
        }

        public IDataResult<List<CourseFile>> GetListByCourseId(int CourseId)
        {
            return new SuccessDataResult<List<CourseFile>>(_courseFileDal.GetList(filter: c => c.CourseId == CourseId).ToList());
        }
    }
}
