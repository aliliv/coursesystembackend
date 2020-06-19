using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CourseFileDto
    {
        
        public List<CourseFile> CourseFiles { get; set; }
        public int CourseId { get; set; }
    }
}
