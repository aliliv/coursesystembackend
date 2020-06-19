using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ActiveSessionListDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
