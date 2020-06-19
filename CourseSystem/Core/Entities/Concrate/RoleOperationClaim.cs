using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrate
{
    public class RoleOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
