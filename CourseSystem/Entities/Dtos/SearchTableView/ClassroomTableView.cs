using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.SearchTableView
{
    public class ClassroomTableView
    {
        public int Id { get; set; }
        public string Branch { get; set; }
        public string ClassName { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
    }
}
