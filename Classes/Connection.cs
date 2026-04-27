using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopContent_Markov.Classes
{
    public class Connection
    {
        private static readonly string config = "server=localhost;port=3306;database=ShopContent;user=root;password=;";

        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(config);
            connection.Open();
            return connection;
        }

        public static MySqlDataReader Query(string SQL, out MySqlConnection connection)
        {
            connection = OpenConnection();
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
        }
    }
}
