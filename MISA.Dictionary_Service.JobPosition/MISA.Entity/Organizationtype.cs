using System;
using System.Collections.Generic;
using MISA.Entity.Base;
namespace MISA.Entity
{
    public partial class Organizationtype : BaseEntity
    {
        public Organizationtype()
        {
            OrganizationTypeId = Guid.NewGuid();
        }

        public Guid OrganizationTypeId { get; set; }
        public string OrganizationTypeName { get; set; }
        public Guid? ParentId { get; set; }
     

       
    }
}
