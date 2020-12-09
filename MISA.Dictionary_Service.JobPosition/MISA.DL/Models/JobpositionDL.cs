using MISA.DL.Base;
using MISA.DL.Common;
using MISA.DL.Interface;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.DL.Models
{
    public class JobpositionDL : BaseDBContext<Jobposition>, IBaseDL<Jobposition>
    {
        public Jobposition DeleteEntityById(string id)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_DeleteById(\"" + id + "\")"));
            if (tmp == null)
                return null;

            else return tmp[0];
          
        }

        public Jobposition GetEntityById(string id)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_GetById(\"" + id + "\")"));
            if (tmp == null)
                return null;

            else return tmp[0];
        }

        public List<Jobposition> GetListEntity()
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_GetAll()")); 
            if (tmp == null)
                return null;

            else return tmp;
           
            
        }
        /// <summary>
        /// Lấy dữ liệu phân trang
        /// CreatedBY: NDVIET
        /// CreatedDate: 26/11/2020
        /// </summary>
        /// <returns>Danh sach đối tượng</returns>
        public List<Jobposition> GetListEntityPageData(int startIndex, int pageSize)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_GetPageData("+startIndex+","+pageSize+")"));
            if (tmp == null)
                return null;

            else return tmp;


        }

        public Jobposition InsertEntity(Jobposition entity)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_Insert('"+entity.JobPositionId+"','"+entity.JobPositionName+"')"));
            if (tmp == null)
                return null;

            else return tmp[0];
            
        }

        public Jobposition UpdateEntity(Jobposition entity)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_Update('" + entity.JobPositionId + "','" + entity.JobPositionName + "')"));
            if (tmp == null)
                return entity;

            else return tmp[0];


         
        }
        public List<Jobposition> GetListEntityInJobpositionType(String jobpositionTypeId)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Organizationtypejobposition_GetListJobposition('" + jobpositionTypeId + "')"));
            if (tmp == null)
                return null;

            else return tmp;


        }
        public long CountAllData()
        {
           var tmp= this.dBContext.ExecuteSQL("Call Proc_Jobposition_CountAllData()");
            tmp.Read();
           
            return  long.Parse(tmp["countall"].ToString());
        }
        public long CountAllSearchData(string searchKey)
        {
            var tmp = this.dBContext.ExecuteSQL("Call Proc_Jobposition_CountSearchResult('"+searchKey+"')");
            tmp.Read();

            return long.Parse(tmp["countall"].ToString());
        }
        public List<Jobposition> GetListEntitySearchPageData(int startIndex, int pageSize, string searchKey)
        {
            var tmp = Convertor.ReaderToJobposition(this.dBContext.ExecuteSQL("call Proc_Jobposition_GetSearchPageData(" + startIndex + "," + pageSize + ",'"+searchKey+"')"));
            if (tmp == null)
                return null;

            else return tmp;


        }
        /// <summary>
        /// Lấy các chức danh , chức vụ mà tổ chức cần sử dụng
        /// Created BY: NDVIET
        /// Created Date: 9/12/2020
        /// </summary>
        /// <param name="organizationCode">Mã tổ chức<param>
        /// <returns>Danh sách chức danh chức vụ </returns>
        public List<JobpositionData> GetJobpositionByOrganizationCode(String organizationCode)
        {
            var tmp = Convertor.ReaderToJobpositionData(this.dBContext.ExecuteSQL("call Proc_Jobposition_GetByOrganizationCode('" + organizationCode + "')"));
            if (tmp == null)
                return null;

            else return tmp;


        }
        public Boolean UpdateJobpositionByOrganizationCode(String organizationCode,String listJobpositionId)
        {
            var tmp = this.dBContext.ExecuteSQL("call Proc_Jobposition_UpdateByOrganizationCode('" + organizationCode + "','"+ listJobpositionId + "')");
            tmp.Read();

            if (long.Parse(tmp["countall"].ToString()) > 0)
                return true;
            else return false;
           


        }

        
    }
}
