using MISA.BL.Interface;
using MISA.DL.Interface;
using MISA.DL.Models;
using MISA.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MISA.DL.Base;
namespace MISA.BL.Base
{
  public class BaseBL<T> : IBaseBL<T> where T : BaseEntity
    {
        IBaseDL<T> DL ;
       
       public BaseBL()
        {
            this.DL = new BaseDLL<T>();

        }

        public Task<T> DeleteEntityById(string id)
        {
            return this.DL.DeleteEntityById(id);
        }

        public Task<T> GetEntityById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetListEntity()
        {
            return this.DL.GetListEntity();
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
