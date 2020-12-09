using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.API.Common;
using MISA.API.Models;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
   
    public class JobpositionnouseController : Controller
    {

        [HttpPost]
        public ActionServiceResult Post([FromBody] Jobposition entity, [FromQuery] String organizationTypeId)
        {
            dynamic tmp = null;
            if (organizationTypeId == "" || organizationTypeId == null)
            {
              //  tmp = new JobpositionBL().InsertEntity(entity);

            }
            else
            {
                //tmp = new OrganizationtypejobpositionBL(organizationTypeId).InsertEntity(entity);
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
