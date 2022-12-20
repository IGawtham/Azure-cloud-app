using System.Data.SqlClient;
using WebApp.Models;

namespace WebApp.Services
{
    public class ProductService
    {
        private static string db_source = "sqldb00.database.windows.net";
        private static string db_user = "dbadmin";
        private static string db_password = "Password$";
        private static string _db = "appdb";

        private SqlConnection GetConnection()
        {
            var _builer = new SqlConnectionStringBuilder();
            _builer.DataSource = db_source;
            _builer.UserID = db_user;
            _builer.Password = db_password;
            _builer.InitialCatalog = _db;
            return new SqlConnection(_builer.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> product_list = new List<Product>();
            String Query = "Select Id,Name,Quantity From Product";
            conn.Open();
            SqlCommand command = new SqlCommand(Query, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    product_list.Add(product);
                }
            }
            conn.Close();
            return product_list;
        }
    }
}
