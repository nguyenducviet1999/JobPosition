using MISA.DL.Base;
using MISA.DL.Interface;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Models
{
   public class OrganizationDL : BaseDLL<Organization>
    {
        public Task<Organization> DeleteEntityById(String id)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetEntityById(String id)
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
