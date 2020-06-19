using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICourseDal : IEntityRepository<Course>
    {
        ReturnCourseSearchDto GetListTableView(CourseSearchDto courseSearchDto);
    }
}
