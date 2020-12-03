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
   public class OrganizationtypejobpositionDL : BaseDBContext<Organizationtypejobposition>
    {
        
        public List<Jobposition> GetListEntityPageData(int startIndex, int pageSize, string oganizationType)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Organizationtypejobposition_GetListJobposition('"+oganizationType+"'," + startIndex + "," + pageSize + ")"));
            if (tmp == null)
                return null;

            else return tmp;

        }

        public Jobposition InsertEntity(Jobposition entity, string oganizationType)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Organizationtypejobposition_Insert('" + oganizationType+ "','" + entity.JobPositionId + "','"+ entity.JobPositionName+ "')"));
            if (tmp == null)
                return null;

            else return tmp[0];

        }

        public Jobposition UpdateEntity(Jobposition entity,string oldJobpositionId, string oganizationType)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Organizationtypejobposition_Update('"+oganizationType+"','" + oldJobpositionId + "','" + entity.JobPositionId + "','" + entity.JobPositionName+ "')"));
            if (tmp == null)
                return null;

            else return tmp[0];

        }
        public Jobposition DeleteEntityById(string id, string oganizationType)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Organizationtypejobposition_DeleteById('"+ oganizationType + "','"+ id + "')"));
            if (tmp == null)
                return null;

            else return tmp[0];
        }

        public long CountAllData(string oganizationType)
        {
            var tmp = this.dBContext.ExecuteSQL("Call Proc_Organizationtypejobposition_CountAllDtata('"+ oganizationType + "')");
            tmp.Read();

            return long.Parse(tmp["countall"].ToString());
        }
        public long CountAllSearchData(string searchKey, string oganizationType)
        {
            var tmp = this.dBContext.ExecuteSQL("Call Proc_Organizationtypejobposition_CountAllSearchData('"+ oganizationType + "','" + searchKey + "')");
            tmp.Read();

            return long.Parse(tmp["countall"].ToString());
        }
        public List<Jobposition> GetListEntitySearchPageData(int startIndex, int pageSize, string searchKey, string oganizationType)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Organizationtypejobposition_GetSearchPageData('"+oganizationType+"'," + startIndex + "," + pageSize + ",'" + searchKey + "')"));
            if (tmp == null)
                return null;

            else return tmp;


        }
        public List<Jobposition> GetListInsertEntity(string oganizationType)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Organizationtypejobposition_GetListInsertData('"+ oganizationType + "')"));
            if (tmp == null)
                return null;

            else return tmp;


        }

    }
}

