using MISA.DL.Base;
using MISA.DL.Common;
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
            var tmp = Convertor.ReaderToOrganizationtype(this.dBContext.ExecuteSQL("call Proc_Organizationtype_GetAll()"));
            if (tmp == null)
                return null;

            else return tmp;
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
