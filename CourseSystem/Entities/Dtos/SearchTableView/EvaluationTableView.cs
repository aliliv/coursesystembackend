using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.SearchTableView
{
    public class EvaluationTableView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PassingGrade { get; set; }
        public bool Status { get; set; }
        public string Branch { get; set; }
    }
}
