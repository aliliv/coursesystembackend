using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.SearchTableView
{
    public class CourseTableView
    {
        public int Id { get; set; }
        public string Branch { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int DaysInWeek { get; set; }
        public bool Status { get; set; }
    }
}
