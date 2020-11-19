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
            List<Jobposition> result = new List<Jobposition>();
            while (reader.Read())
            {
                Jobposition _jobposition = new Jobposition();
                if (reader["jobPositionID"].ToString())
                {
                    _jobposition.JobPositionId = Guid.Parse(reader["UserId"].ToString());
                }
                if (reader["jobPositionName"].ToString())
                {
                    _jobposition.JobPositionName = reader["jobPositionName"].ToString();
                }
                result.Add(_jobposition);
            }
           

            return result;
        }

        public static Jobpositionnouse ReaderToJobpositionnouse(dynamic reader)
        {
            Jobpositionnouse _jobpositionnouse = new Jobpositionnouse();
            if (reader["jobPositionID"].ToString())
            {
                _jobpositionnouse.JobPositionId = Guid.Parse(reader["UserId"].ToString());
            }
            if (reader["organizationCode"].ToString())
            {
                _jobpositionnouse.OrganizationCode = reader["organizationCode"].ToString();
            }


            return _jobpositionnouse;
        }
    }
}
