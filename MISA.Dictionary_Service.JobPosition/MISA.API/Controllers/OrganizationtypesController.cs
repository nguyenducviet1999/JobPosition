using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    {
        // GET: api/<OganizationtypesController>
        [HttpGet]
        public ActionServiceResult Get()
        {
            var tmp = new OrganizationtypeBL().GetListEntity();
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Exception, tmp);
            }


        }
        /// <summary>
        /// Hàm lấy các chức danh chức vụ chưa có trong loại tổ chức
        /// </summary>
        /// <param name="organizationTypeId">Id loại tổ chức</param>
        /// <returns></returns>
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
                return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp);
            }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }

    }
}
