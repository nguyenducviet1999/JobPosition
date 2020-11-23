using MISA.BL.Interface;
using MISA.DL.Models;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Models
{
    public class JobpositionBL : IBaseBL<Jobposition>
    {
        JobpositionDL _jobpositionDL = new JobpositionDL();
        public Jobposition DeleteEntityById(string id)
        {
            var tmp = _jobpositionDL.DeleteEntityById(id);
            if (tmp != null)
            {
                return tmp;
            }
            return new Jobposition();


        }

        public Jobposition GetEntityById(string id)
        {
            var tmp = _jobpositionDL.GetEntityById(id);
            if (tmp != null)
            { 
                return tmp; 
            }
            return new Jobposition();
           
        }

        public List<Jobposition> GetListEntity()
        {

            
            return _jobpositionDL.GetListEntity();
        }

        public Jobposition InsertEntity(Jobposition entity)
        {
            return _jobpositionDL.InsertEntity(entity);
        }

        public Jobposition UpdateEntity(Jobposition entity)
        {
            return _jobpositionDL.UpdateEntity(entity);
        }
        public List<Jobposition> GetListEntityInJobpositionType(String jobpositionTypeId)
        {
            return _jobpositionDL.GetListEntityInJobpositionType(jobpositionTypeId);
        }
    }
}
