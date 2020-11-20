using MISA.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Interface
{
    public interface IBaseDL<T> where T : BaseEntity
    {
        List<T> GetListEntity();
        T GetEntityById(String id);
        T InsertEntity(T entity);
        T UpdateEntity(T entity);
        T DeleteEntityById(String id);

    }
}
