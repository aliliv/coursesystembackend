using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public IDataResult<Course> Add(Course course)
        {
            return new SuccessDataResult<Course>(_courseDal.AddReturnEntity(course), Messages.CourseAdded);
        }

        public IDataResult<Course> GetById(int courseid)
        {
            return new SuccessDataResult<Course>(_courseDal.Get(filter: c => c.Id == courseid));
        }

        public IDataResult<List<Course>> GetList()
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetList().ToList());
        }

        public IDataResult<ReturnCourseSearchDto> GetListByFilter(CourseSearchDto courseSearchDto)
        {
            return new SuccessDataResult<ReturnCourseSearchDto>(_courseDal.GetListTableView(courseSearchDto));
        }

        public IResult Update(Course course)
        {
            _courseDal.Update(course);
            return new SuccessResult(Messages.CourseUpdate);
        }

    }
}
