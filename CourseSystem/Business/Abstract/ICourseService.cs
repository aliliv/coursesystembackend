using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICourseService
    {
        IDataResult<Course> GetById(int courseid);
        IResult Update(Course course);
        IDataResult<ReturnCourseSearchDto> GetListByFilter(CourseSearchDto course);
        IDataResult<List<Course>> GetList();
        IDataResult<Course> Add(Course course);
    }
}
