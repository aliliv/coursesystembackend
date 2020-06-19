using Core.Entities;
using Entities.Dtos.SearchTableView;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.ReturnSearchDto
{
    public class ReturnCourseSearchDto:IDto
    {
        public List<CourseTableView> TableView { get; set; }
        public int TotalCount { get; set; }
        public int MaxPage { get; set; }
    }
}
