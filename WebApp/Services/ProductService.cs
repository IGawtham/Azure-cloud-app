using Microsoft.FeatureManagement;
using System.Data.SqlClient;
using WebApp.Models;

namespace WebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration configuration;
        private readonly IFeatureManager featureManager;
        public ProductService(IConfiguration _configuration, IFeatureManager _featureManager)
        {
            configuration = _configuration;
            featureManager = _featureManager;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(configuration.GetConnectionString("SQLConnection"));
        }
        //To ceck feature flag is enabled or not --beta feature name
        public async Task<bool> IsBeta()
        {
            if (await featureManager.IsEnabledAsync("beta"))
            {
                return true;
            }
            return false;
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
