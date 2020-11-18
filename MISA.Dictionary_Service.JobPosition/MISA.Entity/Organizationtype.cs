using System;
using System.Collections.Generic;
using MISA.Entity.Base;
namespace MISA.Entity
{
    public partial class Organizationtype : BaseEntity
    {
        public Organizationtype()
        {
            Organizationtypejobposition = new HashSet<Organizationtypejobposition>();
        }

        public Guid OrganizationTypeId { get; set; }
        public string OrganizationTypeName { get; set; }
        public Guid? Idparent { get; set; }
     

        public virtual ICollection<Organizationtypejobposition> Organizationtypejobposition { get; set; }
    }
}
