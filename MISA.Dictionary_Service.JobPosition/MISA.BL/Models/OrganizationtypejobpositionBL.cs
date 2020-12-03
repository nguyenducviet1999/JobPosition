
using MISA.BL.Interface;
using MISA.DL.Models;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Models
{
  public  class OrganizationtypejobpositionBL 
    {
        OrganizationtypejobpositionDL _organizationtypejobposition = new OrganizationtypejobpositionDL();
        public String OganizationType;
      public  OrganizationtypejobpositionBL(string oganizationType)
        {
            OganizationType = oganizationType;
        }

        public void DisconnectDb()
        {
            this._organizationtypejobposition.dBContext.DisConnectDB();
        }
        public void OpenconnectionDd()
        {
            this._organizationtypejobposition.dBContext.ConnectDB();
        }
 
   
        public List<Jobposition> GetListEntityPageData(int pageIndex, int pageSize)
        {
            int _startIndex = (pageIndex - 1) * pageSize;

            var tmp = _organizationtypejobposition.GetListEntityPageData(_startIndex, pageSize, OganizationType);
            return tmp;
        }
        public List<Jobposition> GetListEntitySearchPageData(int pageIndex, int pageSize, string searchKey)
        {
            int _startIndex = (pageIndex - 1) * pageSize;

            var tmp = _organizationtypejobposition.GetListEntitySearchPageData(_startIndex, pageSize, searchKey, OganizationType);
            return tmp;
        }
  
        public long CountAllData()
        {
            var tmp = _organizationtypejobposition.CountAllData(OganizationType);
            return tmp;
        }
    
        public long CountAllSearchData(string searchKey)
        {
            var tmp = _organizationtypejobposition.CountAllSearchData(searchKey, OganizationType);
            return tmp;
        }
    
        public Jobposition InsertEntity(Jobposition entity)
        {
            return _organizationtypejobposition.InsertEntity(entity, OganizationType);
        }
    
        public Jobposition UpdateEntity(Jobposition entity,string oldJobpositionId)
        {
            return _organizationtypejobposition.UpdateEntity(entity, oldJobpositionId, OganizationType);
        }
        public Jobposition DeleteEntityById(string id)
        {
            var tmp = _organizationtypejobposition.DeleteEntityById(id, OganizationType);
            if (tmp != null)
            {
                return tmp;
            }
            return new Jobposition();


        }
        public List<Jobposition> GetListInsertEntity()
        {
            var tmp = _organizationtypejobposition.GetListInsertEntity(OganizationType);
         
                return tmp;
         


        }

    }
}
