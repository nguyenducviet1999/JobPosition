﻿using System;
using System.Collections.Generic;
using MISA.Entity.Base;
namespace MISA.Entity
{
    public partial class Jobpositionnouse : BaseEntity 
    {

        public Guid JobPositionId { get; set; }
        public String OrganizationCode { get; set; }

       
    }
}
