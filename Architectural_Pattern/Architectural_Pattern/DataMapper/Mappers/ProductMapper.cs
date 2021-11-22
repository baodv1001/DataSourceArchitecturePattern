using Architectural_Pattern.DataMapper.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architectural_Pattern.DataMapper.Mappers
{
    class ProductMapper : IDataMapper<Product>
    {
        public static SqlConnection conn = new SqlConnection("");

        public Product FindByGuId(Guid uniqueID)
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

                Product product = new Product(guid);
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

        public List<Product> FindAll()
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
                List<Product> result = new List<Product>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Guid guid = Guid.Parse(dataTable.Rows[i].ItemArray[0].ToString());
                    String productName = dataTable.Rows[i].ItemArray[1].ToString();
                    int price = int.Parse(dataTable.Rows[i].ItemArray[2].ToString());
                    string description = dataTable.Rows[i].ItemArray[3].ToString();
                    string image = dataTable.Rows[i].ItemArray[4].ToString();
                    string idBrand = dataTable.Rows[i].ItemArray[5].ToString();
                    string idCategory = dataTable.Rows[i].ItemArray[6].ToString();

                    Product product = new Product(guid);
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

        public void Insert(Product product)
        {
            try
            {
                SqlConnection conn = new SqlConnection("");
                SqlConnection db = null; //connection string here
                db.Open();

                string statement = "INSERT INTO `students`(guid,productName,price, description, image, idBrand, idCategory) " +
                    "values(@guid,@productName,@price, @description, @image, @idBrand, @idCategory)";
                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@productName", product.ProductName);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@image", product.Image);
                command.Parameters.AddWithValue("@idCategory", product.IdCategory);
                command.Parameters.AddWithValue("@idBrand", product.IdBrand);

                command.Parameters.AddWithValue("@guid", product.Guid);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured inserting Students to the data source.", e);
            }
        }

        public void Update(Product product)
        {
            try
            {
                SqlConnection conn = new SqlConnection("");
                SqlConnection db = null; //connection string here
                db.Open();

                string statement = "UPDATE `product` SET `productName`=@productName, `price`=@price, `description`=@description, `image`=@image,`idBrand`=@idBrand, `idCategory`=@idCategory where `guid`=@guid";
                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@productName", product.ProductName);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@image", product.Image);
                command.Parameters.AddWithValue("@idCategory", product.IdCategory);
                command.Parameters.AddWithValue("@idBrand", product.IdBrand);

                command.Parameters.AddWithValue("@guid", product.Guid);
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Error occured updateing Students to the data source.", e);
            }
        }
    }
}
