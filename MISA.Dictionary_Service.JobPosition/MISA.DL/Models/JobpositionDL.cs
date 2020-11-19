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
    public class JobpositionDL : BaseDLL<Jobposition>
    {
        public Task<Jobposition> DeleteEntityById(String id)
        {
            var reader=this.dBContext.ExecuteProceduce("sgs");
           return Convertor.ReaderToJobposition(reader);
            
        }

        public Task<Jobposition> GetEntityById(String id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Jobposition>> GetListEntity()
        {
            return null;
           // var reader = this.dBContext.ExecuteSQL("Select * from jobposition");
            //return Convertor.ReaderToJobposition(reader); throw new NotImplementedException();
        }

        public Task<Jobposition> InsertEntity(Jobposition entity)
        {
            throw new NotImplementedException();
        }

        public Task<Jobposition> UpdateEntity(Jobposition entity)
        {
            throw new NotImplementedException();
        }
    }
}
