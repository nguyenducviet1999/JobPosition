using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.UI.Common;

namespace MISA.UI.Models
{
    
    public class ActionServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public MISACode MISACode { get; set; }
        public object Data { get; set; }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        public ActionServiceResult()
        {
            Success = true;
            Message = "ok";
            MISACode = MISACode.Success;
            Data = null;
        }

        public ActionServiceResult(bool success, string message, MISACode misacode, object data)
        {
            Success = success;
            Message = message;
            MISACode = misacode;
            Data = data;
        }
    }
}
