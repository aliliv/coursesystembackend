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
    public class VisatypeManager : IVisatypeService
    {
        private IVisatypeDal _visatypeDal;
        public VisatypeManager(IVisatypeDal visatypeDal)
        {
            _visatypeDal = visatypeDal;
        }
        public IDataResult<List<Visatype>> GetList()
        {
            return new SuccessDataResult<List<Visatype>>(_visatypeDal.GetList().ToList());
        }
    }
}
