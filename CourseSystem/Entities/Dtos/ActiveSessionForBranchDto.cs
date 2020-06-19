using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ActiveSessionForBranchDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
