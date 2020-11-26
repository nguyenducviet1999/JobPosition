using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interface;
using MISA.BL.Models;
using MISA.Entity;
using MISA.Entity.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.API.Controllers
{
    [Route("api/[controller]")]
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
        public List<Jobposition> Get()
        {
            //var entity = baseBL.GetListEntity();
            return new JobpositionBL().GetListEntity();
        }

        // GET api/<JobpositionsController>/5
        [HttpGet("{id}")]
        public Jobposition Get(String id)
        {
            return new JobpositionBL().GetEntityById(id) ;
        }
        [HttpGet("countalljobposition")]
        public long CoutAllData(String id)
        {
            return new JobpositionBL().CountAllData();
        }
        [HttpGet("paging/{pageindex}/{pagesize}")]
        public List<Jobposition> GetPageData(int pageindex, int pagesize)
        {
            return new JobpositionBL().GetListEntityPageData(pageindex, pagesize);
        }

        [HttpGet("countalljobposition")]
        public long CoutAllSearchData(String searchKey)
        {
            return new JobpositionBL().CountAllSearchData(searchKey);
        }
        [HttpGet("searchpaging/{pageindex}/{pagesize}")]
        public List<Jobposition> GetSearchPageData(int pageindex, int pagesize,[FromBody]string searchKey)
        {
            return new JobpositionBL().GetListEntitySearchPageData(pageindex, pagesize, searchKey);
        }


        [HttpGet("organizationtype/{OrganizationTypeId}")]
        public List<Jobposition> GetListEntityInJobpositionType(String OrganizationTypeId)
         {
            return new JobpositionBL().GetListEntityInJobpositionType(OrganizationTypeId);
        }


        // POST api/<JobpositionsController>
        [HttpPost]
        public Jobposition Post([FromBody] Jobposition entity)
        {
            return new JobpositionBL().InsertEntity(entity);
        }

        // PUT api/<JobpositionsController>/5
        [HttpPut("{id}")]
        public Jobposition Put(Guid id, [FromBody] Jobposition entity)
        {
            entity.JobPositionId = id;
            return new JobpositionBL().UpdateEntity(entity);
        }

        // DELETE api/<JobpositionsController>/5
        [HttpDelete("{id}")]
        public Jobposition Delete(String id)
        {
            return new JobpositionBL().DeleteEntityById(id);
        }
    }
}
