using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.API.Common
{

   

    /// <summary>
    /// Kiểu phương thức 
    /// </summary>
    public enum EntityState
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        GET,

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        INSERT,

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        UPDATE,

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        DELETE
    }

    /// <summary>
    /// Các mã lỗi
    /// </summary>
    public enum MISACode
    {
        Success = 200,

        /// <summary>
        /// Lỗi validate dữ liệu chung
        /// </summary>
        Validate = 400,

        /// <summary>
        /// Lỗi validate dữ liệu không hợp lệ
        /// </summary>
        ValidateEntity = 401,

        /// <summary>
        /// Lỗi validate dữ liệu do không đúng nghiệp vụ
        /// </summary>
        ValidateBussiness = 402,

        /// <summary>
        /// Lỗi không tìm thấy
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Lỗi Exception
        /// </summary>
        Exception = 500,

        /// <summary>
        /// Lỗi Trùng dữ liệu
        /// </summary>
        Duplicate = 501,

        /// <summary>
        /// Lỗi File không đúng định dạng
        /// </summary>
        FileFormat = 600,

        /// <summary>
        /// Lỗi File import không đúng định dạng
        /// </summary>
        ImportFileFormat = 601,

        /// <summary>
        /// Lỗi File Export không đúng định dạng
        /// </summary>
        ExportFileFormat = 602,

        /// <summary>
        /// Lỗi thêm mới entity
        /// </summary>
        ErrorAddEntity = 603,

        /// <summary>
        /// Lỗi xóa entity
        /// </summary>
        ErrorDeleteEntity = 604,
        /// <summary>
        /// Lỗi cập nhật entity
        /// </summary>
        ErrorUpdateEntity = 605,
    }

    public static class Message
    {
        public const string SuccessMess = "Success";
        public const string ErrorMess = "Error";


    }


    public enum CheckBoolean
    {
        /// <summary>
        /// Đúng
        /// </summary>
        True = 1,
        /// <summary>
        /// Sai
        /// </summary>
        False = 0
    }
}
