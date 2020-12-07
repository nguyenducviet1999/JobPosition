using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.API.Common;
using MISA.API.Models;
using MISA.BL.Interface;
using MISA.BL.Models;
using MISA.Entity;
using MISA.Entity.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JobpositionsController : ControllerBase
    {
      
       

        /// <summary>
        /// Hàm lấy chức danh, chức vụ theo id
        /// Created By: NDVIET
        /// Created Date: 5/12/2020
        /// </summary>
        /// <param name="id">Id chức danh chức vụ</param>
        /// <param name="organizationTypeId">Id loại tổ chức </param>
        /// <returns></returns>
        // GET api/<JobpositionsController>/5
        [HttpGet("{id}")]
        public ActionServiceResult Get(String id, [FromQuery] String organizationTypeId)
        {
            dynamic tmp = null;
            if (organizationTypeId == "" || organizationTypeId == null)
            {

                tmp = new JobpositionBL().GetEntityById(id);

            }
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }
        /// <summary>
        /// Hàm đếm tổng số lượng các chức danh, chức vụ
        /// Created By: NDVIET
        /// Created Date: 5/12/2020
        /// </summary>
        /// <param name="organizationTypeId">Id loại tổ chức</param>
        /// <returns></returns>
        [HttpGet("total")]
        public ActionServiceResult CoutAllSearchData([FromQuery] String searchKey, [FromQuery] String organizationTypeId)
        {
            dynamic tmp = null;
            if (organizationTypeId == "" || organizationTypeId == null)
            {
                tmp = new JobpositionBL().CountAllSearchData(searchKey);

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationTypeId).CountAllSearchData(searchKey);
            }
            if (tmp == null)
            {
                return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp);
            }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }
        /// <summary>
        /// Hàm lấy dữ liệu phân trang chức danh, chức vụ
        /// Created By: NDVIET
        /// Created Date: 5/12/2020
        /// </summary>
        /// <param name="pageindex">Giá trị trang hiện tại</param>
        /// <param name="pagesize">Số lượng bản ghi trong một trang</param>
        /// <param name="organizationTypeId">Id loại tổ chức</param>
        /// <returns></returns>
        [HttpGet("{pageindex}/{pagesize}")]
        public ActionServiceResult GetSearchPageData(int pageindex, int pagesize, [FromQuery] string searchKey, [FromQuery] String organizationTypeId)
        {
            dynamic tmp = null;
            if (organizationTypeId == "" || organizationTypeId == null)
            {
                tmp = new JobpositionBL().GetListEntitySearchPageData(pageindex, pagesize, searchKey);

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationTypeId).GetListEntitySearchPageData(pageindex, pagesize, searchKey);
            }
            if (tmp == null)
            {
                return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp);
            }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }
       


        /// <summary>
        /// Thêm một chức danh chức vụ mới
        /// Created By: NDVIET
        /// Created Date: 5/12/2020
        /// </summary>
        /// <param name="entity">Đối tượng chức danh chức vụ mới</param>
        /// <param name="organizationTypeId">Id loại tổ chức</param>
        /// <returns></returns>
        // POST api/<JobpositionsController>
        [HttpPost]
        public ActionServiceResult Post([FromBody] Jobposition entity, [FromQuery] String organizationTypeId)
        {
            dynamic tmp = null;
            if (organizationTypeId == "" || organizationTypeId == null)
            {
                tmp = new JobpositionBL().InsertEntity(entity);

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationTypeId).InsertEntity(entity);
            }

            if (tmp == null)
            {
                return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp);
            }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }
        /// <summary>
        /// Sửa chức danh, chức vụ
        /// Created By: NDVIET
        /// Created Date: 5/12/2020
        /// </summary>
        /// <param name="id">Id chức danh, chức vụ</param>
        /// <param name="entity">Đối tượng sau khi chỉnh sửa</param>
        /// <param name="organizationTypeId">Id loại tổ chức</param>
        /// <returns></returns>
        // PUT api/<JobpositionsController>/5
        [HttpPut("{id}")]
        public ActionServiceResult Put(Guid id, [FromBody] Jobposition entity, [FromQuery] String organizationTypeId)
        {
            dynamic tmp = null;
            if (organizationTypeId == "" || organizationTypeId == null)
            {
                entity.JobPositionId = id;
                tmp = new JobpositionBL().UpdateEntity(entity);

            }
            else
            {

                tmp = new OrganizationtypejobpositionBL(organizationTypeId).UpdateEntity(entity, id.ToString()); ;
            }
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }
        /// <summary>
        /// Xóa một chức danh chức vụ
        /// Created By: NDVIET
        /// Created Date: 5/12/2020
        /// </summary>
        /// <param name="id">Id chức danh chức vụ cần xóa</param>
        /// <param name="organizationTypeId">Id loại tổ chức</param>
        /// <returns></returns>
        // DELETE api/<JobpositionsController>/5
        [HttpDelete("{id}")]
        public ActionServiceResult Delete(String id, [FromQuery] String organizationTypeId)
        {
            dynamic tmp = null;
            if (organizationTypeId == "" || organizationTypeId == null)
            {
                tmp = new JobpositionBL().DeleteEntityById(id);

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationTypeId).DeleteEntityById(id);
            }

            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }
        /// <summary>
        /// Hàm xóa danh sách chức danh chức vụ
        /// Created By: NDVIET
        /// Created Date: 5/12/2020
        /// </summary>
        /// <param name="listId">Danh sách ID chức danh chức vụ muốn xóa</param>
        /// <param name="organizationTypeId">Id loại tổ chức</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionServiceResult DeleteListEntity(List<string> listId, [FromQuery] String organizationTypeId)
        {
            dynamic tmp = null;
            if (organizationTypeId == "" || organizationTypeId == null)
            {
                List<string> resultData = new List<string>();
                JobpositionBL jobPositionBl = new JobpositionBL();

                for (int i = 0; i < listId.Count(); i++)
                {
                    jobPositionBl.OpenconnectionDd();
                    tmp = jobPositionBl.DeleteEntityById(listId[i]);
                    jobPositionBl.DisconnectDb();
                    if (tmp != null)
                    {
                        resultData.Add(tmp.JobPositionId.ToString());
                    }

                }

                if (resultData.Count == 0)
                { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, resultData); }
                else
                {
                    return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, resultData);
                }
            }
            else
            {
                List<string> resultData = new List<string>();
                OrganizationtypejobpositionBL organizationtypeJobPositionBl = new OrganizationtypejobpositionBL(organizationTypeId);

                for (int i = 0; i < listId.Count(); i++)
                {
                    organizationtypeJobPositionBl.OpenconnectionDd();
                    tmp = organizationtypeJobPositionBl.DeleteEntityById(listId[i]);
                    organizationtypeJobPositionBl.DisconnectDb();
                    if (tmp != null)
                    {
                        resultData.Add(tmp.JobPositionId.ToString());
                    }

                }

                if (resultData.Count == 0)
                { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, resultData); }
                else
                {
                    return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, resultData);
                }
            }

        }
    }
}
