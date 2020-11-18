using System;
using System.Collections.Generic;
using MISA.Entity.Base;

namespace MISA.Entity
{
    public partial class Organization : BaseEntity
    {
        public Guid OrganizationId { get; set; }
        public string OrganizationCode { get; set; }
        public string OrganizationName { get; set; }
        public Guid? OrganizationTypeId { get; set; }
     
    }
}
