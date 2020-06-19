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
   public class EFClassroomDal : EfEntityRepositoryBase<Classroom, CourseSystemContext>, IClassroomDal
    {
        public List<ActiveClassroomListDto> GetActiveClassList()
        {
            using (var context = new CourseSystemContext())
            {
                var result = from classroom in context.Classrooms
                             join branch in context.Branchs
                              on classroom.BranchId equals branch.Id
                             where classroom.Status == true
                             select new ActiveClassroomListDto { Id=classroom.Id,ClassName=classroom.ClassName,BranchName=branch.Name };
                return result.ToList();
            }
        }

        public ReturnClassroomSearchDto GetListTableView(ClassroomSearchDto classroomSearchDto)
        {
            ReturnClassroomSearchDto returnClassroomSearchDto = new ReturnClassroomSearchDto();
            using (var context = new CourseSystemContext())
            {
                var result = (from classroom in context.Classrooms
                              join userbranch in context.UserBranchs
                              on classroom.BranchId equals userbranch.BranchId
                              join branch in context.Branchs
                              on classroom.BranchId equals branch.Id
                              where classroom.Status == classroomSearchDto.Status && userbranch.UserId == classroomSearchDto.UserId &&
                              classroom.ClassName.Contains(classroomSearchDto.SearchObj.ClassName) 
                              select new ClassroomTableView
                              {
                                  Id = classroom.Id,
                                  ClassName = classroom.ClassName,
                                  Capacity = classroom.Capacity,
                                  Status = classroom.Status,
                                  Branch = branch.Name
                              }).ToList();
                returnClassroomSearchDto.TableView = result.Skip((classroomSearchDto.Page - 1) * classroomSearchDto.PageSize).Take(classroomSearchDto.PageSize).ToList();
                returnClassroomSearchDto.TotalCount = result.Count();
                returnClassroomSearchDto.MaxPage = Convert.ToInt32(Math.Ceiling((double)returnClassroomSearchDto.TotalCount / (double)classroomSearchDto.PageSize));
            }
            return returnClassroomSearchDto;
        }
    }
}
