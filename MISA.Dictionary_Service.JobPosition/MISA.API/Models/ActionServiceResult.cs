using MISA.API.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.API.Models
{
    public class ActionServiceResult
    {
        public String traceID { get; set; }
        public string Message { get; set; }
        public Code Code { get; set; }
        public object Data { get; set; }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        public ActionServiceResult()
        {
            traceID = "";
            Message = "Success";
            Code = Code.Success;
            Data = null;
        }

        public ActionServiceResult(String traceId, string message, Code misacode, object data)
        {
           
            traceID = traceId;
            Message = message;
            Code = misacode;
            Data = data;
        }
    }
}
