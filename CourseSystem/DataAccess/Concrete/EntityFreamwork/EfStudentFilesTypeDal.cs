using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfStudentFilesTypeDal : EfEntityRepositoryBase<StudentFilesType, CourseSystemContext>, IStudentFilesTypeDal
    {
    }
}
