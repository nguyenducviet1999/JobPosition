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
   public class OrganizationtypejobpositionDL : BaseDBContext<Organizationtypejobposition>, IBaseDL<Organizationtypejobposition>
    {
        public Organizationtypejobposition DeleteEntityById(string id)
        {
            var tmp = Convertor.ReaderToOrganizationtypejobposition(this.dBContext.ExecuteSQL("call Proc_Organizationtypejobposition_DeleteById(\"" + id + "\")"));
            if (tmp == null)
                return null;

            else return tmp[0];
            
        }

        public Organizationtypejobposition GetEntityById(string id)

        {
            throw new NotImplementedException();
        }

        public List<Organizationtypejobposition> GetListEntity()
        {
            
            throw new NotImplementedException();
        }

        public Organizationtypejobposition InsertEntity(Organizationtypejobposition entity)
        {
            var tmp = Convertor.ReaderToOrganizationtypejobposition(this.dBContext.ExecuteSQL("call Proc_Organizationtypejobposition_Insert('" + entity.OrganizationTypeJobPositionId + "','" + entity.JobPositionId + "','" + entity.OrganizationTypeId + "')"));
            if (tmp == null)
                return null;

            else return tmp[0];
        }

        public Organizationtypejobposition UpdateEntity(Organizationtypejobposition entity)
        {
            var tmp = Convertor.ReaderToOrganizationtypejobposition(this.dBContext.ExecuteSQL("call Proc_Organizationtypejobposition_Update('" + entity.OrganizationTypeJobPositionId + "','" + entity.JobPositionId + "','" + entity.OrganizationTypeId + "')"));
            if (tmp == null)
                return null;

            else return tmp[0];
        }
    }
}
