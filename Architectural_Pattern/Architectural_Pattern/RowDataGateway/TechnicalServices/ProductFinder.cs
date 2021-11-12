using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architectural_Pattern.RowDataGateway.TechnicalServices
{
    class ProductFinder
    {
        public static SqlConnection conn = new SqlConnection("");
        public ProductGateway FindByGuId(Guid uniqueID)
        {

            try
            {
                SqlConnection db = null; //connection string here
                db.Open();

                string statement = "SELECT * FROM `product` where `guid`=@guid";

                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@guid", uniqueID);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new(command);

                DataTable dataTable = new();
                adapter.Fill(dataTable);

                Guid guid = Guid.Parse(dataTable.Rows[0].ItemArray[0].ToString());
                String productName = dataTable.Rows[0].ItemArray[1].ToString();
                int price = int.Parse(dataTable.Rows[0].ItemArray[2].ToString());
                string description = dataTable.Rows[0].ItemArray[3].ToString();
                string image = dataTable.Rows[0].ItemArray[4].ToString();
                string idBrand = dataTable.Rows[0].ItemArray[5].ToString();
                string idCategory = dataTable.Rows[0].ItemArray[6].ToString();

                ProductGateway product = new ProductGateway(guid);
                product.ProductName = productName;
                product.Price = price;
                product.Description = description;
                product.Image = image;
                product.IdBrand = idBrand;
                product.IdCategory = idCategory;
                return product;

            }
            catch (Exception e)
            {
                throw new Exception("Error occured reading Product from the data source.", e);
            }
        }
        public List<ProductGateway> FindAll()
        {
            return new List<ProductGateway>();
        }
        public List<ProductGateway> FindProducts() //grade A
        {
            try
            {
                SqlConnection db = null; //connection string here
                db.Open();
                string statement = "SELECT * FROM `product` ";
                SqlCommand command = new(statement, conn);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new(command);

                DataTable dataTable = new();
                adapter.Fill(dataTable);
                List<ProductGateway> result = new List<ProductGateway>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Guid guid = Guid.Parse(dataTable.Rows[i].ItemArray[0].ToString());
                    String productName = dataTable.Rows[i].ItemArray[1].ToString();
                    int price = int.Parse(dataTable.Rows[i].ItemArray[2].ToString());
                    string description = dataTable.Rows[i].ItemArray[3].ToString();
                    string image = dataTable.Rows[i].ItemArray[4].ToString();
                    string idBrand = dataTable.Rows[i].ItemArray[5].ToString();
                    string idCategory = dataTable.Rows[i].ItemArray[6].ToString();

                    ProductGateway product = new ProductGateway(guid);
                    product.ProductName = productName;
                    product.Price = price;
                    product.Description = description;
                    product.Image = image;
                    product.IdBrand = idBrand;
                    product.IdCategory = idCategory;
                    result.Add(product);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error occured reading Products from the data source.", e);
            }
        }
    }
}
