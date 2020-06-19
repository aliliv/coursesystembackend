using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.ReturnSearchDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IAssignmentDal : IEntityRepository<Assignment>
    {
        ReturnAssignmentSearchDto GetListTableView(AssignmentSearchDto assignmentSearchDto);
    }
}
