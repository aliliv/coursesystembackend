using Core.Entities;
using Entities.Concrete;
using Entities.Dtos.SearchObj;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CourseSearchDto:IDto
    {
        public CourseSearchObj SearchObj { get; set; }
        public bool Status { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int UserId { get; set; }

    }
}
