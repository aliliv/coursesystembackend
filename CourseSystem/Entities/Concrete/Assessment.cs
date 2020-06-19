using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Assessment:IEntity
    {
        public int Id { get; set; }
        public int InstitutionId { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
    }
}
