using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebSite.Database
{
    public class DBConnection : IDisposable
    {
        private readonly SqlConnection connection;

        public DBConnection()
        {
        connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        connection.Open();

        }

        public void ExecuteCommand(string StrQuery)
        {
            var Command = new SqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text,
                Connection = connection
                
            };

            Command.ExecuteNonQuery();
        }


        public SqlDataReader RetornaComando(string Strquery)
        {
            var comando = new SqlCommand(Strquery, connection);
            return comando.ExecuteReader();

        }


        public void Dispose()
        {
           connection.Close();
        }
    }
}