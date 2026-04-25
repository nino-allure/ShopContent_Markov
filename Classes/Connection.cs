using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ShopContent_Markov.Classes
{
    public class Connection
    {
        private readonly string config = "server=localhost;" + "Trusted_Connection=No;" + "DataBase=ShopContent;" + "User=root;" + "PWD=;";
        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(config);
            connection.Open();
            return connection;
        }
        public static SqlDataReader Query(string SQL, out SqlConnection connection)
        {
            connection = OpenConnection();
            return new SqlCommand(SQL, connection).ExecuteReader();
        }
        public static void CloseConnection(SqlConnection connection)
        {
            connection.Close();
            SqlCommand.ClearPool(connection);
        }
    }
}
