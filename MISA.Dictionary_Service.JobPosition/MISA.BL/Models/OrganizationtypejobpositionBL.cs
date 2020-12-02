
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
        OrganizationtypejobpositionBL(string oganizationType)
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
 
   
        public List<Jobposition> GetListEntityPageData(int pageIndex, int pageSize, string oganizationType)
        {
            int _startIndex = (pageIndex - 1) * pageSize;

            var tmp = _organizationtypejobposition.GetListEntityPageData(_startIndex, pageSize, oganizationType);
            return tmp;
        }
        public List<Jobposition> GetListEntitySearchPageData(int pageIndex, int pageSize, string searchKey, string oganizationType)
        {
            int _startIndex = (pageIndex - 1) * pageSize;

            var tmp = _organizationtypejobposition.GetListEntitySearchPageData(_startIndex, pageSize, searchKey, oganizationType);
            return tmp;
        }
  
        public long CountAllData(string oganizationType)
        {
            var tmp = _organizationtypejobposition.CountAllData( oganizationType);
            return tmp;
        }
    
        public long CountAllSearchData(string searchKey, string oganizationType)
        {
            var tmp = _organizationtypejobposition.CountAllSearchData(searchKey, oganizationType);
            return tmp;
        }
    
        public Jobposition InsertEntity(Jobposition entity, string oganizationType)
        {
            return _organizationtypejobposition.InsertEntity(entity, oganizationType);
        }
    
        public Jobposition UpdateEntity(Jobposition entity,string oldJobpositionId, string oganizationType)
        {
            return _organizationtypejobposition.UpdateEntity(entity, oldJobpositionId, oganizationType);
        }
    }
}
