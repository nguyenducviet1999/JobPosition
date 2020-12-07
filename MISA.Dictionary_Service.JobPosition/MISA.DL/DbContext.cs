using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace MISA.DL
{
    public class DBContext
    {

        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataReader sqlDataReader;
        public DBContext()
        {
            
           var _connectionStr = new MySqlConnectionStringBuilder
            {
               //Server = "10.0.6.14",
               Server = "localhost",
                Database = "dictionary_service_jobposition",
                UserID = "root",
                Password = "12345678@Abc",
                ConnectionTimeout = 60,
                Port = 3306,
                AllowZeroDateTime = true
            };
            sqlConnection = new MySqlConnection(_connectionStr.ConnectionString);

            try
            {
                ConnectDB();
               
            }
            catch
            {
                Console.WriteLine("Error, help i can't get connected!");
            }
            sqlCommand = sqlConnection.CreateCommand();

           // sqlConnection = new SqlConnection("Server=10.0.6.14,3306;database=dictionary_service_jobposition;user=root;password=12345678@Abc");
            //sqlCommand = sqlConnection.CreateCommand();
            // Server = 35.194.135.168; port = 3306; database = MISA_Dictionary_Development; user = dev; password = 12345678@Abc; CharSet = utf8
            //Server=127.0.0.1; Initial Catalog=ADONETEXAMPLE; User ID=testado; Password=testado.net; Application Name=Test ADP.NET
            //Server=10.0.6.14;port=3306;database=dictionary_service_jobposition;user=root;password=12345678@Abc;CharSet=utf8
        }
        public dynamic ExecuteSQL(String sql)
        {

            ConnectDB();
            this.sqlCommand.CommandText = sql;
                var result=this.sqlCommand.ExecuteReader();
            //DisConnectDB();
            return result;
        }
        public dynamic ExecuteProceduce(String sql)
        {
            ConnectDB();
            this.sqlCommand.CommandType = CommandType.StoredProcedure;
            this.sqlCommand.CommandText = sql;
            var result = this.sqlCommand.ExecuteReader();
            //DisConnectDB();
            return result;
          
        }
        public void ConnectDB()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }

        }
        public void DisConnectDB()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }

        }
    }
}
