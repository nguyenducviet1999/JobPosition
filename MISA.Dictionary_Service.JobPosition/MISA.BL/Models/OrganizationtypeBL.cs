using MISA.DL.Interface;
using MISA.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Models
{
    class OrganizationtypeBL : IBaseDL<Organizationtype>
    {
        public Task<Organizationtype> DeleteEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Organizationtype> GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Organizationtype>> GetListEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Organizationtype> InsertEntity(Organizationtype entity)
        {
            throw new NotImplementedException();
        }

        public Task<Organizationtype> UpdateEntity(Organizationtype entity)
        {
            throw new NotImplementedException();
        }
    }
}
