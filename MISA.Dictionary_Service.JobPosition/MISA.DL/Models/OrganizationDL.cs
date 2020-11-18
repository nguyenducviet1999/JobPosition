using MISA.DL.Interface;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Models
{
   public class OrganizationDL : IBaseDL<Organization>
    {
        public Task<Organization> DeleteEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Organization>> GetListEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Organization> InsertEntity(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> UpdateEntity(Organization entity)
        {
            throw new NotImplementedException();
        }
    }
}
