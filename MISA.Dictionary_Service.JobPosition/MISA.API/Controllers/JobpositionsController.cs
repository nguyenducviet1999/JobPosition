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
        private readonly IBaseBL<BaseEntity> baseBL;

        public JobpositionsController(IBaseBL<BaseEntity> baseBL)
        {
            this.baseBL = baseBL;
        }


        // GET: api/<JobpositionsController>
        [HttpGet]
        public List<Jobposition> Get()
        {
            var entity = baseBL.GetListEntity();
            return new JobpositionBL().GetListEntity();
        }

        // GET api/<JobpositionsController>/5
        [HttpGet("{id}")]
        public Jobposition Get(String id)
        {
            return new JobpositionBL().GetEntityById(id) ;
        }

        // POST api/<JobpositionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JobpositionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobpositionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
