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
    public class JobpositionnouseDL : BaseDBContext<Jobpositionnouse>, IBaseDL<Jobpositionnouse>
    {
        public Jobpositionnouse DeleteEntityById(string id)
        {
            var tmp = Convertor.ReaderToJobpositionnouse(this.dBContext.ExecuteSQL("call Proc_Jobpositionnouse_DeleteById(\"" + id + "\")"));
            if (tmp == null)
                return null;

            else return tmp[0];
        }

        public Jobpositionnouse GetEntityById(string id)
        {
            var tmp = Convertor.ReaderToJobpositionnouse(this.dBContext.ExecuteSQL("call Proc_Jobpositionnouse_GetById(\"" + id + "\")"));
            if (tmp == null)
                return null;

            else return tmp[0];
        }

        public List<Jobpositionnouse> GetListEntity()
        {
            var tmp = Convertor.ReaderToJobpositionnouse(this.dBContext.ExecuteSQL("call Proc_Jobpositionnouse_GetAll"));
            if (tmp == null)
                return null;

            else return tmp;
        }

        public Jobpositionnouse InsertEntity(Jobpositionnouse entity)
        {
            var tmp = Convertor.ReaderToJobpositionnouse(this.dBContext.ExecuteSQL("call Proc_Jobpositionnouse_GetAll"));
            if (tmp == null)
                return null;

            else return tmp[0];
        }

        public Jobpositionnouse UpdateEntity(Jobpositionnouse entity)
        {
            var tmp = Convertor.ReaderToJobpositionnouse(this.dBContext.ExecuteSQL("call Proc_Jobpositionnouse_GetAll"));
            if (tmp == null)
                return null;

            else return tmp[0];
        }
    }
}
