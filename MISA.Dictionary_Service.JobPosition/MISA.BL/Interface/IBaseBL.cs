using MISA.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MISA.DL.Interface;
using MISA.Entity;

namespace MISA.BL.Interface
{
    public interface IBaseBL<K>where K : BaseEntity 
    {

        List<K> GetListEntity();
        K GetEntityById(String id);
        K InsertEntity(K entity);
        K UpdateEntity(K entity);
        K DeleteEntityById(String id);
    }
}
