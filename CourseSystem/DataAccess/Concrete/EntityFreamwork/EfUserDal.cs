using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrate;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using Entities.Dtos.SearchTableView;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfUserDal : EfEntityRepositoryBase<User, CourseSystemContext>, IUserDal
    {
        public List<ActiveTaacherListDto> GetActiveTeacher()
        {
            using (var context = new CourseSystemContext())
            {
                var result = from user in context.Users
                             where user.RoleId == 3 && user.Status==true
                             select new ActiveTaacherListDto { Id=user.Id,FirstName=user.FirstName,LastName=user.LastName};
                return result.ToList();
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CourseSystemContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join roleOperationClaim in context.RoleOperationClaims
                             on operationClaim.Id equals roleOperationClaim.OperationClaimId
                             where roleOperationClaim.RoleId == user.RoleId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name,ParentId=operationClaim.ParentId,InstitutionId=operationClaim.InstitutionId,Visibility=operationClaim.Visibility };
                return result.ToList();
            }
        }

        public ReturnUserSearchDto GetListTableView(UserSearchDto userSearchDto)
        {
            ReturnUserSearchDto returnUserSearchDto = new ReturnUserSearchDto();
            using (var context = new CourseSystemContext())
            {
                var result = (from user in context.Users
                              join role in context.Roles
                              on user.RoleId equals role.Id
                              //join userbranch in context.UserBranchs
                              //on user.Id equals userbranch.UserId
                              where user.Status == userSearchDto.Status && 
                              (userSearchDto.SearchObj.RoleId==0 || user.RoleId==userSearchDto.SearchObj.RoleId) &&
                              (user.FirstName.Contains(userSearchDto.SearchObj.SearchWord) || (user.LastName.Contains(userSearchDto.SearchObj.SearchWord)))
                              select new UserTableView
                              {
                                  Id = user.Id,
                                  FirstName=user.FirstName,
                                  LastName=user.LastName,
                                  Role=role.RoleName,
                                  Status=user.Status
                              }).ToList();
                returnUserSearchDto.TableView = result.Skip((userSearchDto.Page - 1) * userSearchDto.PageSize).Take(userSearchDto.PageSize).ToList();
                returnUserSearchDto.TotalCount = result.Count();
                returnUserSearchDto.MaxPage = Convert.ToInt32(Math.Ceiling((double)returnUserSearchDto.TotalCount / (double)userSearchDto.PageSize));
            }
            return returnUserSearchDto;
        }
    }
}
