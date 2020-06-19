using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos.SearchObj
{
    public class AssignmentSearchObj
    {
        public int SessionId { get; set; }
        public int TeacherId { get; set; }
        public int ClassroomId { get; set; }
    }
}
