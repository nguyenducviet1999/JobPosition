using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace MISA.DL
{
    class DBContext
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        DBContext()
        {
        }
    }
}
