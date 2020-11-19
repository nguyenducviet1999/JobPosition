using MISA.DL.Base;
using MISA.DL.Interface;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Models
{
    class OrganizationtypeDL : BaseDLL<Organization> 
    {
        public Task<Organization> DeleteEntityById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetEntityById(string id)
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
