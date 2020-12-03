using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Models;
using MISA.Entity;
using MISA.UI.Common;
using MISA.UI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.UI.Controllers
{
    [Route("page/api/[controller]")]
    [ApiController]
    public class JobpositionsController : ControllerBase
    {
        //private readonly IBaseBL<BaseEntity> baseBL;

        //public JobpositionsController(IBaseBL<BaseEntity> baseBL)
        //{
        //    this.baseBL = baseBL;
        //}


        // GET: api/<JobpositionsController>
        [HttpGet]
        public ActionServiceResult Get([FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
            {
                tmp = new JobpositionBL().GetListEntity();
                //var entity = baseBL.GetListEntity();

            }


            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }

        }
        [HttpGet("insertdata")]
        public ActionServiceResult GetInserthData([FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
            {
                tmp = null;

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationType).GetListInsertEntity();
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

        // GET api/<JobpositionsController>/5
        [HttpGet("{id}")]
        public ActionServiceResult Get(String id, [FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
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
        [HttpGet("countalljobposition")]
        public ActionServiceResult CoutAllData([FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
            {
                tmp = new JobpositionBL().CountAllData();
                //var entity = baseBL.GetListEntity();

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationType).CountAllData();
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
        [HttpGet("paging/{pageindex}/{pagesize}")]
        public ActionServiceResult GetPageData(int pageindex, int pagesize, [FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
            {
                tmp = new JobpositionBL().GetListEntityPageData(pageindex, pagesize);

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationType).GetListEntityPageData(pageindex, pagesize);
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

        [HttpGet("countallsearchdata")]
        public ActionServiceResult CoutAllSearchData([FromQuery] String searchKey, [FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
            {
                tmp = new JobpositionBL().CountAllSearchData(searchKey);

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationType).CountAllSearchData(searchKey);
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
        [HttpGet("searchpaging/{pageindex}/{pagesize}")]
        public ActionServiceResult GetSearchPageData(int pageindex, int pagesize, [FromQuery] string searchKey, [FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
            {
                tmp = new JobpositionBL().GetListEntitySearchPageData(pageindex, pagesize, searchKey);

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationType).GetListEntitySearchPageData(pageindex, pagesize, searchKey);
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


        [HttpGet("organizationtype/{OrganizationTypeId}")]
        public ActionServiceResult GetListEntityInJobpositionType(String OrganizationTypeId, [FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
            {
                tmp = new JobpositionBL().GetListEntityInJobpositionType(OrganizationTypeId);

            }

            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }


        // POST api/<JobpositionsController>
        [HttpPost]
        public ActionServiceResult Post([FromBody] Jobposition entity, [FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
            {
                tmp = new JobpositionBL().InsertEntity(entity);

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationType).InsertEntity(entity);
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

        // PUT api/<JobpositionsController>/5
        [HttpPut("{id}")]
        public ActionServiceResult Put(Guid id, [FromBody] Jobposition entity, [FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
            {
                tmp = new JobpositionBL().UpdateEntity(entity);

            }
            else
            {

                tmp = new OrganizationtypejobpositionBL(organizationType).UpdateEntity(entity, id.ToString()); ;
            }
            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }

        // DELETE api/<JobpositionsController>/5
        [HttpDelete("{id}")]
        public ActionServiceResult Delete(String id, [FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
            {
                tmp = new JobpositionBL().DeleteEntityById(id);

            }
            else
            {
                tmp = new OrganizationtypejobpositionBL(organizationType).DeleteEntityById(id);
            }

            if (tmp == null)
            { return new ActionServiceResult(false, Message.ErrorMess, Common.MISACode.Exception, tmp); }
            else
            {
                return new ActionServiceResult(true, Message.SuccessMess, Common.MISACode.Success, tmp);
            }
        }
        [HttpDelete("deleteListJobpositionId")]
        public ActionServiceResult DeleteListEntity(List<string> listId, [FromQuery] String organizationType)
        {
            dynamic tmp = null;
            if (organizationType == "" || organizationType == null)
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
                OrganizationtypejobpositionBL organizationtypeJobPositionBl = new OrganizationtypejobpositionBL(organizationType);

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
