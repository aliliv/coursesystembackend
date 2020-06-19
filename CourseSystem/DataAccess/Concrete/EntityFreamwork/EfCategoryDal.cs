using Entities.Concrete;
using Core.DataAccess.EntityFreamwork;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,CourseSystemContext>,ICategoryDal
    {

    }
}
