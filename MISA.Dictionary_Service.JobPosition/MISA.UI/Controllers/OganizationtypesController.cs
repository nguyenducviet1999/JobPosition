using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Models;
using MISA.UI.Common;
using MISA.UI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.UI.Controllers
{
    [Route("page/api/[controller]")]
    [ApiController]
    public class OganizationtypesController : ControllerBase
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

    }
}
