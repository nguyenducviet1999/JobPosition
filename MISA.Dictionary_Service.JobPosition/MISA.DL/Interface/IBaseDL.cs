using MISA.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Interface
{
    public interface IBaseDL<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetListEntity();
        Task<T> GetEntityById(Guid id);
        Task<T> InsertEntity(T entity);
        Task<T> UpdateEntity(T entity);
        Task<T> DeleteEntityById(Guid id);

    }
}
