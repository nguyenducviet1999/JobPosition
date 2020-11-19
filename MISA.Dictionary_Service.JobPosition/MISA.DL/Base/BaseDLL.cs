using MISA.DL.Common;
using MISA.DL.Interface;
using MISA.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Base
{
   public class BaseDLL<T> : BaseDBContext<T>, IBaseDL<T> where T : BaseEntity
    {
        public Task<T> DeleteEntityById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetEntityById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetListEntity()
        {
            throw new NotImplementedException();
        }

        public Task<T> InsertEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
