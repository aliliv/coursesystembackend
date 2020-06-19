using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class StudentFileDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocationUrl { get; set; }
        public string StudentFilesType { get; set; }
        public bool Status { get; set; }
    }
}
