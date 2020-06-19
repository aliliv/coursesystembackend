using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ClassroomManager : IClassroomService
    {
        private IClassroomDal _classroomDal;
        public ClassroomManager(IClassroomDal classroomDal)
        {
            _classroomDal = classroomDal;
        }
        public IResult Add(Classroom classroom)
        {
            _classroomDal.Add(classroom);
            return new SuccessResult(Messages.ClassAdded);
        }
        public IDataResult<List<Classroom>> GetList()
        {
            return new SuccessDataResult<List<Classroom>>(_classroomDal.GetList().ToList());
        }
        public IDataResult<Classroom> GetById(int classroomid)
        {
            return new SuccessDataResult<Classroom>(_classroomDal.Get(filter: c => c.Id == classroomid));
        }
        public IResult Update(Classroom classroom)
        {
            _classroomDal.Update(classroom);
            return new SuccessResult(Messages.ClassUpdate);
        }

        public IDataResult<ReturnClassroomSearchDto> GetListByFilter(ClassroomSearchDto classroomSearchDto)
        {
            return new SuccessDataResult<ReturnClassroomSearchDto>(_classroomDal.GetListTableView(classroomSearchDto));
        }

        public IDataResult<List<ActiveClassroomListDto>> GetActiveClassList()
        {
            return new SuccessDataResult<List<ActiveClassroomListDto>>(_classroomDal.GetActiveClassList());
        }
    }
}
