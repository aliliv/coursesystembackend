using Core.DataAccess;
using Core.Entities.Concrate;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserBranchDal : IEntityRepository<UserBranch>
    {
    }
}
