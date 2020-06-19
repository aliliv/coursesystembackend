using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CourseFile:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string LocationUrl { get; set; }
        public int CourseFileTypeId { get; set; }
        public int CourseId { get; set; }

    }
}
