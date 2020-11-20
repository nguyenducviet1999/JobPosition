using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.Common
{
    public static class Convertor
    {
        public static List<Jobposition> ReaderToJobposition(dynamic reader)
        {
            List<Jobposition> _result = new List<Jobposition>();
            while (reader.Read())
            {
                Jobposition _jobposition = new Jobposition();
                
                
                    _jobposition.JobPositionId = Guid.Parse(reader["jobPositionID"].ToString());
                
              
                    _jobposition.JobPositionName = reader["jobPositionName"].ToString();
                
                _result.Add(_jobposition);
            }
            

            if (_result.Count == 0) return null;
            return _result;
        }

        public static List<Jobpositionnouse> ReaderToJobpositionnouse(dynamic reader)
        {
            List<Jobpositionnouse>  _result = new List<Jobpositionnouse>();
            while (reader.Read())
            {
                Jobpositionnouse _jobpositionnouse = new Jobpositionnouse();

                _jobpositionnouse.JobPositionId = Guid.Parse(reader["jobPositionID"].ToString());
                _jobpositionnouse.OrganizationCode = reader["organizationCode"].ToString();
                _result.Add(_jobpositionnouse);
            }


            if (_result.Count == 0) return null;
            return _result;
        }
    }
}
