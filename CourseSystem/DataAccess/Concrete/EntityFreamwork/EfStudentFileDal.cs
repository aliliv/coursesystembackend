using Core.DataAccess.EntityFreamwork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFreamwork
{
    public class EfStudentFileDal: EfEntityRepositoryBase<StudentFile, CourseSystemContext>, IStudentFileDal
    {
        public List<StudentFileDto> GetStudentFile(int userid)
        {
            using (var context = new CourseSystemContext())
            {
                var result = from studentfile in context.StudentFiles
                             join studentfiletype in context.StudentFilesTypes
                             on studentfile.StudentFilesType equals studentfiletype.Id
                             where studentfile.UserId == userid
                             select new StudentFileDto { Id =studentfile.Id,Name=studentfile.Name,LocationUrl=studentfile.LocationUrl,
                             StudentFilesType=studentfiletype.Name,Status=studentfile.Status
                             };
                return result.ToList();
            }
        }

    }
}
