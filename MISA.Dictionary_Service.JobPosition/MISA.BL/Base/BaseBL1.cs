﻿using MISA.BL.Interface;
using MISA.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL.Base
{
    public class BaseBL1<K> : IBaseBL<K> where K: BaseEntity
    {
        public K DeleteEntityById(string id)
        {
            throw new NotImplementedException();
        }

        public K GetEntityById(string id)
        {
            return null;
        }

        public List<K> GetListEntity()
        {
            throw new NotImplementedException();
        }

        public K InsertEntity(K entity)
        {
            throw new NotImplementedException();
        }

        public K UpdateEntity(K entity)
        {
            throw new NotImplementedException();
        }
    }
}
