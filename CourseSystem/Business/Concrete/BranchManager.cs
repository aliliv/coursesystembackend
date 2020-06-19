using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        private IBranchDal _branchDal;
        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }
        public IDataResult<List<Branch>> GetList()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetList().ToList());
        }
        public IResult Add(Branch branch)
        {
            _branchDal.Add(branch);
            return new SuccessResult(Messages.BranchAdded);
        }
        public Branch GetByBranchId(int branchid)
        {
           return _branchDal.Get(filter: b => b.Id == branchid);
        }
    }
}
