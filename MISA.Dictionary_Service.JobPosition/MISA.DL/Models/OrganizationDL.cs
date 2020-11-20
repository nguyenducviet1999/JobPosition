using MISA.DL.Base;
using MISA.DL.Interface;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Models
{
    public class OrganizationDL : BaseDBContext<Organization>, IBaseDL<Organization>
    {
        public Organization DeleteEntityById(string id)
        {
            throw new NotImplementedException();
        }

        public Organization GetEntityById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Organization> GetListEntity()
        {
            throw new NotImplementedException();
        }

        public Organization InsertEntity(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Organization UpdateEntity(Organization entity)
        {
            throw new NotImplementedException();
        }
    }
}
