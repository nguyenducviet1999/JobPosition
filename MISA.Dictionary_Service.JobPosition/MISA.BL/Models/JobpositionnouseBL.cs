
using MISA.BL.Interface;
using MISA.DL.Models;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Models
{
    class JobpositionnouseBL : IBaseBL<Jobpositionnouse>
    {
        JobpositionnouseDL _jobpositionnouseDL = new JobpositionnouseDL();
        public Jobpositionnouse DeleteEntityById(string id)
        {
            return _jobpositionnouseDL.DeleteEntityById(id);
        }

        public Jobpositionnouse GetEntityById(string id)
        {
            return _jobpositionnouseDL.GetEntityById(id);
        }

        public List<Jobpositionnouse> GetListEntity()
        {
            return _jobpositionnouseDL.GetListEntity();
        }

        public Jobpositionnouse InsertEntity(Jobpositionnouse entity)
        {
            return _jobpositionnouseDL.InsertEntity(entity);
        }

        public Jobpositionnouse UpdateEntity(Jobpositionnouse entity)
        {
            return _jobpositionnouseDL.UpdateEntity(entity);
        }
    }
}
