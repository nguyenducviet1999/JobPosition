﻿using System;
using System.Collections.Generic;
using MISA.Entity.Base;
namespace MISA.Entity
{
    public class Organizationtypejobposition : BaseEntity
    {
       public Organizationtypejobposition()
        {
            OrganizationTypeJobPositionId = Guid.NewGuid();

        }
        public Guid OrganizationTypeJobPositionId { get; set; }
        public Guid JobPositionId { get; set; }
        public Guid OrganizationTypeId { get; set; }
     
        }
}
