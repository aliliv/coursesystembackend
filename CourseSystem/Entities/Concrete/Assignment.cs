using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Assignment:IEntity
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int TeacherId { get; set; }
        public int ClassroomId { get; set; }
        public int AssignmentDayId { get; set; }
        public bool Status { get; set; }
    }
}
