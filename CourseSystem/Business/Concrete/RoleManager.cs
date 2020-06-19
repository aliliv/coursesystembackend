using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;     
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public IDataResult<List<Role>> GetListByInstitutionId(int InstitutionId)
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetList(filter: p => p.InstitutionId == InstitutionId).ToList());
        }
    }
}
