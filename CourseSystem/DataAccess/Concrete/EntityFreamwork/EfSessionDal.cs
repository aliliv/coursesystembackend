using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Dtos;
using Entities.Dtos.SearchTableView;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfSessionDal : EfEntityRepositoryBase<Session, CourseSystemContext>, ISessionDal
    {
        public List<ActiveSessionForBranchDto> GetActiveSessionForBranch(int branchid)
        {
            using (var context = new CourseSystemContext())
            {
                var result = from session in context.Sessions
                             join course in context.Courses
                             on session.Course equals course.Id
                             where session.Status == true && course.BranchId==branchid
                             select new ActiveSessionForBranchDto { Id=session.Id,Name=course.CourseName+" "+session.StartDate.ToShortDateString()+"-"+session.EndDate.ToShortDateString()};
                return result.ToList();
            }
        }

        public List<ActiveSessionListDto> GetActiveSessionList()
        {
            using (var context = new CourseSystemContext())
            {
                var result = from session in context.Sessions
                             join course in context.Courses
                             on session.Course equals course.Id
                             where session.Status == true
                             select new ActiveSessionListDto {Id=session.Id,CourseName=course.CourseName,StartDate=session.StartDate.ToShortDateString(),EndDate=session.EndDate.ToShortDateString()  };
                return result.ToList();
            }
        }

        public ReturnSessionSearchDto GetListTableView(SessionSearchDto sessionSearchDto)
        {
            ReturnSessionSearchDto returnSessionSearchDto = new ReturnSessionSearchDto();
            using (var context = new CourseSystemContext())
            {
                var result = (from session in context.Sessions
                              join evaluation in context.Evaluations
                              on session.Evaluation equals evaluation.Id
                              join course in context.Courses
                              on session.Course equals course.Id
                              join userbranch in context.UserBranchs
                              on session.Branch equals userbranch.BranchId
                              join branch in context.Branchs
                              on session.Branch equals branch.Id
                              where session.Status == sessionSearchDto.Status && userbranch.UserId == sessionSearchDto.UserId
                              select new SessionTableView
                              {
                                  Id = session.Id,
                                  Evaluation = evaluation.Name,
                                  Status = session.Status,
                                  Cours = course.CourseName,
                                  Tuition = session.Tuition,
                                  StartDate = session.StartDate.ToString("MM/dd/yyyy"),
                                  EndDate = session.EndDate.ToString("MM/dd/yyyy"),
                                  Branch = branch.Name
                              }).ToList();
                returnSessionSearchDto.TableView = result.Skip((sessionSearchDto.Page - 1) * sessionSearchDto.PageSize).Take(sessionSearchDto.PageSize).ToList();
                returnSessionSearchDto.TotalCount = result.Count();
                returnSessionSearchDto.MaxPage = Convert.ToInt32(Math.Ceiling((double)returnSessionSearchDto.TotalCount / (double)sessionSearchDto.PageSize));
            }
            return returnSessionSearchDto;
        }
    }
}
