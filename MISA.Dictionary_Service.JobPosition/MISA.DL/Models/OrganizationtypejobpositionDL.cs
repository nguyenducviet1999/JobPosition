using MISA.DL.Base;
using MISA.DL.Interface;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Models
{
    class OrganizationtypejobpositionDL : BaseDLL<Organizationtypejobposition>
    {
        public Task<Organizationtypejobposition> DeleteEntityById(String id)
        {
            this.dBContext.ExecuteProceduce("");
            throw new NotImplementedException();
        }

        public Task<Organizationtypejobposition> GetEntityById(String id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Organizationtypejobposition>> GetListEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Organizationtypejobposition> InsertEntity(Organizationtypejobposition entity)
        {
            throw new NotImplementedException();
        }

        public Task<Organizationtypejobposition> UpdateEntity(Organizationtypejobposition entity)
        {
            throw new NotImplementedException();
        }
    }
}
