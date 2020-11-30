
using MISA.BL.Interface;
using MISA.DL.Models;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Models
{
   public class OrganizationBL : IBaseBL<Organization>
    {
        OrganizationDL _organizationDL = new OrganizationDL();
        public Organization DeleteEntityById(string id)
        {
            return _organizationDL.DeleteEntityById(id);
        }

        public Organization GetEntityById(string id)
        {
            return _organizationDL.GetEntityById(id);
;        }

        public List<Organization> GetListEntity()
        {
            return _organizationDL.GetListEntity();
        }

        public Organization InsertEntity(Organization entity)
        {
            return _organizationDL.InsertEntity(entity);
        }

        public Organization UpdateEntity(Organization entity)
        {
            return _organizationDL.UpdateEntity(entity);
        }
    }
}
