using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.SearchTableView
{
    public class SessionTableView
    {
        public int Id { get; set; }
        public string Cours { get; set; }
        public int Tuition { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Evaluation { get; set; }
        public string Branch { get; set; }
        public bool Status { get; set; }
    }
}
