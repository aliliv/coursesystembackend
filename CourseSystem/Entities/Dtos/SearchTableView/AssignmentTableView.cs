using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.SearchTableView
{
    public class AssignmentTableView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }
        public string Class { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Status { get; set; }
    }
}
