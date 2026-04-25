using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopContent_Markov.Modell;
using ShopContent_Markov.Classes;

using System.Data.SqlClient;

namespace ShopContent_Markov.Context
{
    public class CategorysContext : Categorys
    {
        public static ObservableCollection<CategorysContext> AllCategorys()
        {
            ObservableCollection<CategorysContext> allCategorys = new ObservableCollection<CategorysContext>();
            SqlConnection connection;
            SqlDataReader dataCategorys = Connection.Query("SELECT * FROM [dbo].[Categorys]", out connection);
            while (dataCategorys.Read())
            {
                allCategorys.Add(new CategorysContext()
                {
                    Id = dataCategorys.GetInt32(0),
                    Name = dataCategorys.GetString(1),
                });
            }
            Connection.CloseConnection(connection);
            return allCategorys;
        }
    }
}
