using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class StudentFile:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LocationUrl { get; set; }
        public int StudentFilesType { get; set; }
        public bool Status { get; set; }
    }
}
