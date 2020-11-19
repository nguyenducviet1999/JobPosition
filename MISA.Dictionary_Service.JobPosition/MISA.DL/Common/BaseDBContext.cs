using MISA.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Common
{
   public class BaseDBContext<T> where T : BaseEntity
    {
      public  DBContext dBContext = new DBContext();
      

       
    }
}
