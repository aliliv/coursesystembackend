using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class StudentCourse:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SesionId { get; set; }
        public DateTime EarlyLeavingDate { get; set; }
        public string Comment { get; set; }
        public bool ConditionalPass { get; set; }
        public bool Incomplete { get; set; }
        public int AcademicWarning { get; set; }
        public int BehavioralWarning { get; set; }
        public bool Status { get; set; }
    }
}
