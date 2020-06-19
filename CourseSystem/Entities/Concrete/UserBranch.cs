﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserBranch:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
    }
}
