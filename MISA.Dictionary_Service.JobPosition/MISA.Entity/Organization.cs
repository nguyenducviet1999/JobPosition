using System;
using System.Collections.Generic;
using MISA.Entity.Base;

namespace MISA.Entity
{
    public partial class Organization : BaseEntity
    {
        public Organization()
        {
            OrganizationId = Guid.NewGuid();
        }
        public Guid OrganizationId { get; set; }
        public string OrganizationCode { get; set; }
        public string OrganizationName { get; set; }
        public Guid OrganizationTypeId { get; set; }
     
    }
}
