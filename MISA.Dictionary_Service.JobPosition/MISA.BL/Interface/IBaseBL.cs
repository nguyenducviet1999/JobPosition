using MISA.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MISA.DL.Interface;

namespace MISA.BL.Interface
{
    public interface IBaseBL<K>where K : BaseEntity 
    {
        Task<IEnumerable<K>> GetListEntity();
        Task<K> GetEntityById(Guid id);
        Task<K> InsertEntity(K entity);
        Task<K> UpdateEntity(K entity);
        Task<K> DeleteEntityById(Guid id);
    }
}
