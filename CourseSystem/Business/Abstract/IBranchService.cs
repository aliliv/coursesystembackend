﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBranchService
    {
        IDataResult<List<Branch>> GetList();
        IResult Add(Branch branch);
        Branch GetByBranchId(int branchid);
    }
}
