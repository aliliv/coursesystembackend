using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.SearchTableView
{
    public class ReturnAgencySearchDto
    {
        public List<AgencyTableView> TableView { get; set; }
        public int TotalCount { get; set; }
        public int MaxPage { get; set; }
    }
}
