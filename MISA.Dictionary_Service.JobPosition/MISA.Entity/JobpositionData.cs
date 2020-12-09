using MISA.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Entity
{
    public class JobpositionData : BaseEntity
    {
        public Guid JobPositionId { get; set; }
        public string JobPositionName { get; set; }
        
        public bool IsUsed { get; set; }
    }
}
