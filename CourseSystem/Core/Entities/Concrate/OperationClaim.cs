using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrate
{
    public class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? InstitutionId { get; set; }
        public int?  ParentId { get; set; }
        public bool Visibility { get; set; }
    }
}
