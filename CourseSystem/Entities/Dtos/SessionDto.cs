using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class SessionDto:IDto
    {
        public int Id { get; set; }
        public int Course { get; set; }
        public int Tuition { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public int Evaluation { get; set; }
        public int Branch { get; set; }
        public bool Status { get; set; }
    }
}
