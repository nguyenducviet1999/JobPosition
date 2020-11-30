using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobpositionnousesController : ControllerBase
    {
        /// <summary>
        /// Cập nhật thông tin các chức danh chức vụ mà tổ chức sử dụng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobpositionnousesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
