using MISA.DL.Base;
using MISA.DL.Interface;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Models
{
   public class OrganizationtypeDL : BaseDBContext<Organizationtype>, IBaseDL<Organizationtype>
    {
        public Organizationtype DeleteEntityById(string id)
        {
            throw new NotImplementedException();
        }

        public Organizationtype GetEntityById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Organizationtype> GetListEntity()
        {
            throw new NotImplementedException();
        }

        public Organizationtype InsertEntity(Organizationtype entity)
        {
            throw new NotImplementedException();
        }

        public Organizationtype UpdateEntity(Organizationtype entity)
        {
            throw new NotImplementedException();
        }
    }
}
