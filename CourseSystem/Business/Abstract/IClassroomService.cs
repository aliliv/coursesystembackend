using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IClassroomService
    {
        IResult Add(Classroom classroom);
        IDataResult<List<Classroom>> GetList();
        IDataResult<Classroom> GetById(int classroomid);
        IResult Update(Classroom classroom);
        IDataResult<List<ActiveClassroomListDto>> GetActiveClassList();
        IDataResult<ReturnClassroomSearchDto> GetListByFilter(ClassroomSearchDto classroomSearchDto);
    }
}
