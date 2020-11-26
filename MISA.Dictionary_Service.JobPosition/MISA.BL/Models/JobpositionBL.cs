using MISA.BL.Interface;
using MISA.DL.Models;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Models
{
    public class JobpositionBL : IBaseBL<Jobposition>
    {
        JobpositionDL _jobpositionDL = new JobpositionDL();
        /// <summary>
        /// Hàm xóa một chức danh chức vụ theo id của nó
        /// CreatedBy: NDVIET
        /// CreatedDate: 26/11/2020
        /// </summary>
        /// <param name="id">id chức danh chức vụ</param>
        /// <returns>Đối tượng vừa xóa </returns>
        public Jobposition DeleteEntityById(string id)
        {
            var tmp = _jobpositionDL.DeleteEntityById(id);
            if (tmp != null)
            {
                return tmp;
            }
            return new Jobposition();


        }
        /// <summary>
        /// Hàm lấy một chức danh chức vụ theo id của nó
        /// CreatedBy: NDVIET
        /// CreatedDate: 26/11/2020
        /// </summary>
        /// <param name="id">id chức danh chức vụ</param>
        /// <returns>Đối tượng vừa lấy</returns>
        public Jobposition GetEntityById(string id)
        {
            var tmp = _jobpositionDL.GetEntityById(id);
            if (tmp != null)
            { 
                return tmp; 
            }
            return new Jobposition();
           
        }
        /// <summary>
        /// Hàm lấy tất cả dữ liệu
        /// CreatedBy: NDVIET
        /// CreatedDate: 26/11/2020
        /// </summary>
        /// <returns></returns>
        public List<Jobposition> GetListEntity()
        {
            return _jobpositionDL.GetListEntity();
        }
        /// <summary>
        /// Lấy dữ liệu của một trang
        /// CreatedBy: NDVIET
        /// CreatedDate: 26/11/2020
        /// </summary>
        /// <param name="pageIndex">Trang đang hiểu thị</param>
        /// <param name="pageSize">Số bản ghi trong một trang</param>
        /// <returns>Danh sách chức danh chức vụ trong trang</returns>
        public List<Jobposition> GetListEntityPageData(int pageIndex, int pageSize)
        {
            int _startIndex = (pageIndex - 1) * pageSize ;

            var tmp = _jobpositionDL.GetListEntityPageData(_startIndex,pageSize);
            return tmp;
        }
        public List<Jobposition> GetListEntitySearchPageData(int pageIndex, int pageSize, string searchKey)
        {
            int _startIndex = (pageIndex - 1) * pageSize;

            var tmp = _jobpositionDL.GetListEntitySearchPageData(_startIndex, pageSize, searchKey);
            return tmp;
        }
        /// <summary>
        /// Đếm tất cả số lượng bản ghi trong bảng chức danh chức vụ 
        /// CreatedBy: NDVIET
        /// CreatedDate: 26/11/2020
        /// </summary>
        /// <returns>một số</returns>
        public long CountAllData()
        {
            var tmp = _jobpositionDL.CountAllData();
            return tmp;
        }
        /// <summary>
        /// Đếm tất cả số kết quả tim kiếm được
        /// </summary>
        /// <param name="searchKey">Từ khóa tìm kiếm theo tên chức danh chức vụ</param>
        /// <returns> Số lượng kết quả tìm thấy</returns>
        public long CountAllSearchData(string searchKey)
        {
            var tmp = _jobpositionDL.CountAllSearchData(searchKey);
            return tmp;
        }
        /// <summary>
        /// Thêm một đối tượng chức danh chức vụ vào database  
        /// CreatedBy: NDVIET
        /// CreatedDate: 26/11/2020
        /// </summary>
        /// <param name="entity">Đối tượng thêm</param>
        /// <returns>Đối tượng vừa thêm</returns>
        public Jobposition InsertEntity(Jobposition entity)
        {
            return _jobpositionDL.InsertEntity(entity);
        }
        /// <summary>
        /// Cập nhật đối tượng chức danh chức vụ
        /// CreatedBy: NDVIET
        /// CreatedDate: 26/11/2020
        /// </summary>
        /// <param name="entity">đối tương cập nhật mmới với id cũ</param>
        /// <returns>Đối tượng mới </returns>
        public Jobposition UpdateEntity(Jobposition entity)
        {
            return _jobpositionDL.UpdateEntity(entity);
        }
        public List<Jobposition> GetListEntityInJobpositionType(String jobpositionTypeId)
        {
            return _jobpositionDL.GetListEntityInJobpositionType(jobpositionTypeId);
        }
    }
}
