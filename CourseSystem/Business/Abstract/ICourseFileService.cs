using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICourseFileService
    {
        void Add(CourseFile courseFile);
        IDataResult<List<CourseFile>> GetListByCourseId(int CourseId);
        IResult Delete(CourseFile courseFile);
    }
}
