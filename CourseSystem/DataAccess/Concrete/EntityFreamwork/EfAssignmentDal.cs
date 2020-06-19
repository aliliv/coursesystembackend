using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Dtos.SearchTableView;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfAssignmentDal : EfEntityRepositoryBase<Assignment, CourseSystemContext>, IAssignmentDal
    {
        public ReturnAssignmentSearchDto GetListTableView(AssignmentSearchDto assignmentSearchDto)
        {
            ReturnAssignmentSearchDto returnAssignmentSearchDto = new ReturnAssignmentSearchDto();
            using (var context = new CourseSystemContext())
            {
                var result = (from assignment in context.Assignments
                              join session in context.Sessions
                              on assignment.SessionId equals session.Id
                              join course in context.Courses
                              on session.Course equals course.Id
                              join teacher in context.Users
                              on assignment.TeacherId equals teacher.Id
                              join classroom in context.Classrooms
                              on assignment.ClassroomId equals classroom.Id
                              where (assignment.Status == assignmentSearchDto.Status) &&
                              (assignmentSearchDto.SearchObj.SessionId==0 || assignmentSearchDto.SearchObj.SessionId==session.Id) &&
                              (assignmentSearchDto.SearchObj.TeacherId == 0 || assignmentSearchDto.SearchObj.TeacherId == teacher.Id) &&
                              (assignmentSearchDto.SearchObj.ClassroomId == 0 || assignmentSearchDto.SearchObj.ClassroomId == classroom.Id)
                              select new AssignmentTableView
                              {
                                  Id =assignment.Id,
                                  FirstName=teacher.FirstName,
                                  LastName=teacher.LastName,
                                  Class=classroom.ClassName,
                                  CourseName=course.CourseName,
                                  StartDate=session.StartDate.ToShortDateString(),
                                  EndDate=session.EndDate.ToShortDateString(),
                                  Status=assignment.Status,
                              }).ToList();
                returnAssignmentSearchDto.TableView = result.Skip((assignmentSearchDto.Page - 1) * assignmentSearchDto.PageSize).Take(assignmentSearchDto.PageSize).ToList();
                returnAssignmentSearchDto.TotalCount = result.Count();
                returnAssignmentSearchDto.MaxPage = Convert.ToInt32(Math.Ceiling((double)returnAssignmentSearchDto.TotalCount / (double)assignmentSearchDto.PageSize));
            }
            return returnAssignmentSearchDto;
        }
    }
    
}
