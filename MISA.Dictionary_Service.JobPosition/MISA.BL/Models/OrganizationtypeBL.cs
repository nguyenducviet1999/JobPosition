
using MISA.BL.Interface;
using MISA.DL.Models;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Models
{
   public class OrganizationtypeBL : IBaseBL<Organizationtype>
    {
        OrganizationtypeDL _organizationtypeDL = new OrganizationtypeDL();
        public Organizationtype DeleteEntityById(string id)
        {
            return _organizationtypeDL.DeleteEntityById(id);
        }

        public Organizationtype GetEntityById(string id)
        {
            return _organizationtypeDL.GetEntityById(id);
        }

        public List<Organizationtype> GetListEntity()
        {
            return _organizationtypeDL.GetListEntity();
        }

        public Organizationtype InsertEntity(Organizationtype entity)
        {
            return _organizationtypeDL.InsertEntity(entity);
        }

        public Organizationtype UpdateEntity(Organizationtype entity)
        {
            return _organizationtypeDL.UpdateEntity(entity);
        }
    }
}
