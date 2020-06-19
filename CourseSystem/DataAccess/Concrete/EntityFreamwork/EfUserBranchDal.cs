using Core.DataAccess.EntityFreamwork;
using Core.Entities.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfUserBranchDal:EfEntityRepositoryBase<UserBranch, CourseSystemContext>, IUserBranchDal
    {
     
    }
}
