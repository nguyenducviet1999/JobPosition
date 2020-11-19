using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MISA.DL
{
    public class DBContext
    {

        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        public DBContext()
        {
            sqlConnection = new SqlConnection("Server=10.0.6.14; Port=3306;database=dictionary_service_jobposition;User ID=root;Password=12345678@Abc;Application Name=Test ADP.NET");
            sqlCommand = sqlConnection.CreateCommand();
            // Server = 35.194.135.168; port = 3306; database = MISA_Dictionary_Development; user = dev; password = 12345678@Abc; CharSet = utf8
            //Server=127.0.0.1; Initial Catalog=ADONETEXAMPLE; User ID=testado; Password=testado.net; Application Name=Test ADP.NET
        }
        public dynamic ExecuteSQL(String sql)
        {
            this.sqlConnection.Open();
            this.sqlCommand.CommandText = sql;
            return this.sqlCommand.ExecuteReader();
        }
        public dynamic ExecuteProceduce(String sql)
        {
            this.sqlConnection.Open();
            this.sqlCommand.CommandType = CommandType.StoredProcedure;
            this.sqlCommand.CommandText = sql;
            return this.sqlCommand.ExecuteReader();
        }
    }
}
