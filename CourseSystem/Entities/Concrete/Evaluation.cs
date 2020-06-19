using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Evaluation:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double PassingGrade { get; set; }
        public bool Status { get; set; }
        public int BranchId { get; set; }
    }
}
