using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Models;
using MISA.Entity;
using MISA.UI.Common;
using MISA.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.UI.Controllers
{
    [Route("page/api/[controller]")]
    [ApiController]
    public class OrganizationtypeJobpositionController : ControllerBase
    {
        [HttpGet]
        public ActionServiceResult Get()
        {
            var tmp = new JobpositionBL().GetListEntity();
            //var entity = baseBL.GetListEntity();
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }


        }

        // GET api/<JobpositionsController>/5
        [HttpGet("{id}")]
        public ActionServiceResult Get(String id)
        {

            var tmp = new JobpositionBL().GetEntityById(id);
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }
        [HttpGet("countalljobposition")]
        public ActionServiceResult CoutAllData()
        {
            var tmp = new JobpositionBL().CountAllData();
            //var entity = baseBL.GetListEntity();
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }

        }
        [HttpGet("paging/{pageindex}/{pagesize}")]
        public ActionServiceResult GetPageData(int pageindex, int pagesize)
        {
            var tmp = new JobpositionBL().GetListEntityPageData(pageindex, pagesize);
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }

        }

        [HttpGet("countallsearchdata")]
        public ActionServiceResult CoutAllSearchData([FromQuery] String searchKey)
        {
            var tmp = new JobpositionBL().CountAllSearchData(searchKey);
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }
        [HttpGet("searchpaging/{pageindex}/{pagesize}")]
        public ActionServiceResult GetSearchPageData(int pageindex, int pagesize, [FromQuery] string searchKey)
        {
            var tmp = new JobpositionBL().GetListEntitySearchPageData(pageindex, pagesize, searchKey);
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }


        [HttpGet("organizationtype/{OrganizationTypeId}")]
        public ActionServiceResult GetListEntityInJobpositionType(String OrganizationTypeId)
        {
            var tmp = new JobpositionBL().GetListEntityInJobpositionType(OrganizationTypeId);
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }


        // POST api/<JobpositionsController>
        [HttpPost]
        public ActionServiceResult Post([FromBody] Jobposition entity)
        {
            var tmp = new JobpositionBL().InsertEntity(entity);
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }

        // PUT api/<JobpositionsController>/5
        [HttpPut("{id}")]
        public ActionServiceResult Put(Guid id, [FromBody] Jobposition entity)
        {
            entity.JobPositionId = id;
            var tmp = new JobpositionBL().UpdateEntity(entity);
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }

        // DELETE api/<JobpositionsController>/5
        [HttpDelete("{id}")]
        public ActionServiceResult Delete(String id)
        {
            var tmp = new JobpositionBL().DeleteEntityById(id);
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }

    }
}
