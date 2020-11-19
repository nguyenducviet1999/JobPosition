using System;
using System.Collections.Generic;
using MISA.Entity.Base;
namespace MISA.Entity
{
    public partial class Jobposition : BaseEntity
    {
        public Jobposition()
        {
            JobPositionId = Guid.NewGuid();
        }

        public Guid JobPositionId { get; set; }
        public string JobPositionName { get; set; }
       

       
    }
}
