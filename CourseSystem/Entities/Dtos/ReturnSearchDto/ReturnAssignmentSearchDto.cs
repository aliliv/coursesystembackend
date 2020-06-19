using Entities.Dtos.SearchTableView;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.ReturnSearchDto
{
    public class ReturnAssignmentSearchDto
    {
        public List<AssignmentTableView> TableView { get; set; }
        public int TotalCount { get; set; }
        public int MaxPage { get; set; }
    }
}
