using System;
using System.Collections.Generic;
using MISA.Entity.Base;
namespace MISA.Entity
{
    public partial class Jobpositionnouse : BaseEntity 
    {
        public Guid JobPositionId { get; set; }
        public string OrganizationCode { get; set; }

        public virtual Jobpositionnouse Jobposition { get; set; }
    }
}
