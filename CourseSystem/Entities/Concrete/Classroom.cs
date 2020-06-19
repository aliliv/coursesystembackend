using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Classroom : IEntity
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string ClassName { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }

    }
}
