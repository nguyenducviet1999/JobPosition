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
    public class JobpositionDL : BaseDBContext<Jobposition>, IBaseDL<Jobposition>
    {
        public Jobposition DeleteEntityById(string id)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_DeleteById(\"" + id + "\")"));
            if (tmp == null)
                return null;

            else return tmp[0];
          
        }

        public Jobposition GetEntityById(string id)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_GetById(\"" + id + "\")"));
            if (tmp == null)
                return null;

            else return tmp[0];
        }

        public List<Jobposition> GetListEntity()
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_GetAll()")); 
            if (tmp == null)
                return null;

            else return tmp;
           
            
        }

        public Jobposition InsertEntity(Jobposition entity)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_Insert('"+entity.JobPositionId+"','"+entity.JobPositionName+"')"));
            if (tmp == null)
                return null;

            else return tmp[0];
            
        }

        public Jobposition UpdateEntity(Jobposition entity)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_Update('" + entity.JobPositionId + "','" + entity.JobPositionName + "')"));
            if (tmp == null)
                return null;

            else return tmp[0];


         
        }
        public List<Jobposition> GetListEntityInJobpositionType(String jobpositionTypeId)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("Proc_Organizationtypejobposition_GetListJobposition('"+ jobpositionTypeId + "')"));
            if (tmp == null)
                return null;

            else return tmp;


        }

    }
}
