using MISA.DL.Interface;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Models
{
   public class JobpositionDL : IBaseDL<Jobposition>
    {
        public Task<Jobposition> DeleteEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Jobposition> GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Jobposition>> GetListEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Jobposition> InsertEntity(Jobposition entity)
        {
            throw new NotImplementedException();
        }

        public Task<Jobposition> UpdateEntity(Jobposition entity)
        {
            throw new NotImplementedException();
        }
    }
}
