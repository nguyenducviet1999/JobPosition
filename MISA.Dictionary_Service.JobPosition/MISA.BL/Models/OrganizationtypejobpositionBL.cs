
using MISA.BL.Interface;
using MISA.DL.Models;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Models
{
    class OrganizationtypejobpositionBL : IBaseBL<Organizationtypejobposition>
    {
        OrganizationtypejobpositionDL _organizationtypejobposition = new OrganizationtypejobpositionDL();
        public Organizationtypejobposition DeleteEntityById(string id)
        {
            return _organizationtypejobposition.DeleteEntityById(id);
        }

        public Organizationtypejobposition GetEntityById(string id)
        {
            return _organizationtypejobposition.GetEntityById(id);
        }

        public List<Organizationtypejobposition> GetListEntity()
        {
            return _organizationtypejobposition.GetListEntity();
        }

        public Organizationtypejobposition InsertEntity(Organizationtypejobposition entity)
        {
            return _organizationtypejobposition.InsertEntity(entity);
        }

        public Organizationtypejobposition UpdateEntity(Organizationtypejobposition entity)
        {
            return _organizationtypejobposition.UpdateEntity(entity);
        }
    }
}
