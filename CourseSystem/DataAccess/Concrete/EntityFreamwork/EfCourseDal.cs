using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using Entities.Dtos.SearchTableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfCourseDal : EfEntityRepositoryBase<Course, CourseSystemContext>, ICourseDal
    {
        public ReturnCourseSearchDto GetListTableView(CourseSearchDto courseSearchDto)
        {
            ReturnCourseSearchDto returnCourseSearchDto = new ReturnCourseSearchDto();
            using (var context = new CourseSystemContext())
            {
                var result = (from course in context.Courses
                              join userbranch in context.UserBranchs
                              on course.BranchId equals userbranch.BranchId
                              join branch in context.Branchs
                              on course.BranchId equals branch.Id
                              where course.Status == courseSearchDto.Status && userbranch.UserId == courseSearchDto.UserId &&
                              (course.DaysInWeek==courseSearchDto.SearchObj.DaysInWeek || courseSearchDto.SearchObj.DaysInWeek==0) &&
                              (course.CourseName.Contains(courseSearchDto.SearchObj.SearchWord) || (course.Description.Contains(courseSearchDto.SearchObj.SearchWord)))
                              select new CourseTableView
                              {
                                  Id = course.Id,
                                  CourseName=course.CourseName,
                                  DaysInWeek=course.DaysInWeek,
                                  Description=course.Description,
                                  Status=course.Status,
                                  Branch = branch.Name
                              }).ToList();
                returnCourseSearchDto.TableView = result.Skip((courseSearchDto.Page - 1) * courseSearchDto.PageSize).Take(courseSearchDto.PageSize).ToList();
                returnCourseSearchDto.TotalCount = result.Count();
                returnCourseSearchDto.MaxPage = Convert.ToInt32(Math.Ceiling((double)returnCourseSearchDto.TotalCount / (double)courseSearchDto.PageSize));
            }
            return returnCourseSearchDto;
        }
    }
}
