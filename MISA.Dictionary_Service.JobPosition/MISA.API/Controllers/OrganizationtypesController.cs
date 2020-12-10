using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MISA.API.Common;
using MISA.API.Models;
using MISA.BL.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
   
    public class OrganizationtypesController : ControllerBase
    {   /// <summary>
        /// Hàm lấy tất cả các chức danh chức vụ
        /// Created By: NDVIET
        /// Created Date: 5/12/2020
        /// </summary>
        /// <returns>Đối tượng respone chứa dữ liệu</returns>
        // GET: api/<OganizationtypesController>
        [HttpGet]
        public ActionServiceResult Get()
        {
            var tmp = new OrganizationtypeBL().GetListEntity();
            if (tmp == null)
            { return new ActionServiceResult("", Message.ErrorMess, Common.Code.Exception, tmp); }
            else
            {
                return new ActionServiceResult("", Message.SuccessMess, Common.Code.Exception, tmp);
            }


        }
        /// <summary>
        /// Hàm lấy các chức danh chức vụ chưa có trong loại tổ chức hỗ trợ nhập khi thêm chức danh chức vụ vào tổ chức
        /// Created By: NDVIET
        /// Created Date: 5/12/2020
        /// </summary>
        /// <param name="organizationTypeId">Id loại tổ chức</param>
        /// <returns>Đối tượng respone chứa danh sách chức danh chức vụ chưa có trong tổ chức</returns>
        [HttpGet("insertings-jobpositions")]
        public ActionServiceResult GetJobpositionName([FromQuery] String organizationTypeId)
        {
            dynamic tmp = null;
            if (organizationTypeId == "" || organizationTypeId == null)
            {
                tmp = null;

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationTypeId).GetListInsertEntity();
            }
            if (tmp == null)
            {
                return new ActionServiceResult("", Message.ErrorMess, Common.Code.Exception, tmp);
            }
            else
            {
                return new ActionServiceResult("", Message.SuccessMess, Common.Code.Success, tmp);
            }
        }

    }
}
