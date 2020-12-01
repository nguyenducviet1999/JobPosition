using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MISA.DL.Common
{
    public static class Convertor
    {
        const string FormatDateTimeUSString = "%M/%d/yyyy %h:%m:%s tt";
        const string FormatDateTimeVnString = "%d/%M/yyyy %h:%m:%s tt";
        /// <summary>
        /// Hàm chuyển dữ liệu trả về từ DataBase kiểu MySqlDataReader thành Jobposition
        /// </summary>
        /// CreatedBy: NDVIET 
        /// CreatedDate: 23/11/2020
        /// <param name="reader">một biến kiểu MySqlDataReader</param>
        /// <returns>Danh sách chức danh chức vụ </returns>
        public static List<Jobposition> ReaderToJobposition(dynamic reader)
        {
            List<Jobposition> _result = new List<Jobposition>();
            while (reader.Read())
            {
                Jobposition _jobposition = new Jobposition();
                
                
                    _jobposition.JobPositionId = Guid.Parse(reader["jobPositionID"].ToString());
                
              
                    _jobposition.JobPositionName = reader["jobPositionName"].ToString();
                    _jobposition.CreatedDate = DateTime.Parse(reader["createdDate"].ToString());
                    if(reader["modifiedDate"].ToString()!="")
                    { 
                        _jobposition.ModifiedDate = DateTime.Parse(reader["modifiedDate"].ToString() );
                    
                }

              

                _result.Add(_jobposition);
            }
            

            if (_result.Count == 0) return null;
            return _result;
        }
        /// <summary>
        /// Hàm chuyển dữ liệu trả về từ DataBase kiểu MySqlDataReader thành Jobpositionnouse
        /// </summary>
        /// CreatedBy: NDVIET 
        /// CreatedDate: 23/11/2020
        /// <param name="reader">một biến kiểu MySqlDataReader</param>
        /// <returns>Danh sách Jobpositionnouse </returns>
        public static List<Jobpositionnouse> ReaderToJobpositionnouse(dynamic reader)
        {
            List<Jobpositionnouse>  _result = new List<Jobpositionnouse>();
            while (reader.Read())
            {
                Jobpositionnouse _jobpositionnouse = new Jobpositionnouse();

                _jobpositionnouse.JobPositionId = Guid.Parse(reader["jobPositionID"].ToString());
                _jobpositionnouse.OrganizationCode = reader["organizationCode"].ToString();
                _jobpositionnouse.CreatedDate = DateTime.Parse(reader["createdDate"].ToString() );
                if (reader["modifiedDate"].ToString() != "")
                {
                     _jobpositionnouse.ModifiedDate = DateTime.Parse(reader["modifiedDate"].ToString() );
                }
               
                _result.Add(_jobpositionnouse);
            }


            if (_result.Count == 0) return null;
            return _result;
        }
        /// <summary>
        /// Hàm chuyển dữ liệu trả về từ DataBase kiểu MySqlDataReader thành Organizationtypejobposition
        /// </summary>
        /// CreatedBy: NDVIET 
        /// CreatedDate: 23/11/2020
        /// <param name="reader">một biến kiểu MySqlDataReader</param>
        /// <returns>Danh sách Organizationtypejobposition </returns>
        public static List<Organizationtypejobposition> ReaderToOrganizationtypejobposition(dynamic reader)
        {
            List<Organizationtypejobposition> _result = new List<Organizationtypejobposition>();
            while (reader.Read())
            {
                Organizationtypejobposition _organizationtypejobposition = new Organizationtypejobposition();

                _organizationtypejobposition.JobPositionId = Guid.Parse(reader["jobPositionID"].ToString());
                _organizationtypejobposition.OrganizationTypeId = Guid.Parse(reader["organizationTypeID"].ToString());
                _organizationtypejobposition.OrganizationTypeJobPositionId = Guid.Parse(reader["organizationTypeJobPositionID"].ToString());

                _organizationtypejobposition.CreatedDate = DateTime.Parse(reader["createdDate"].ToString() );
                if (reader["modifiedDate"].ToString() != "")
                {
                        _organizationtypejobposition.ModifiedDate = DateTime.Parse(reader["modifiedDate"].ToString() );
                }
                
                _result.Add(_organizationtypejobposition);
            }


            if (_result.Count == 0) return null;
            return _result;
        }
        /// <summary>
        /// Hàm chuyển dữ liệu trả về từ DataBase kiểu MySqlDataReader thành Organizationtype
        /// </summary>
        /// CreatedBy: NDVIET 
        /// CreatedDate: 23/11/2020
        /// <param name="reader">một biến kiểu MySqlDataReader</param>
        /// <returns>Danh sách Organizationtype </returns>
        public static List<Organizationtype> ReaderToOrganizationtype(dynamic reader)
        {
            List<Organizationtype> _result = new List<Organizationtype>();
            while (reader.Read())
            {
                Organizationtype _organizationtype = new Organizationtype();

                
                if (reader["parentID"].ToString() != "")
                {
                    _organizationtype.ParentId = Guid.Parse(reader["parentID"].ToString());
                }
                _organizationtype.OrganizationTypeId = Guid.Parse(reader["organizationTypeID"].ToString());
                _organizationtype.OrganizationTypeName = reader["organizationTypeName"].ToString();

                _organizationtype.CreatedDate = DateTime.Parse(reader["createdDate"].ToString() );
                if (reader["modifiedDate"].ToString() != "")
                {
                    _organizationtype.ModifiedDate = DateTime.Parse(reader["modifiedDate"].ToString() );
                }
                
                _result.Add(_organizationtype);
            }


            if (_result.Count == 0) return null;
            return _result;
        }

       
    }
}
