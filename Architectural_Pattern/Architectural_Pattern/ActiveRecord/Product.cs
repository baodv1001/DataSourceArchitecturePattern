using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architectural_Pattern.ActiveRecord
{
    class Product
    {
        private Guid guid; // Note that unique ID is read-only!
        private string productName;
        private int price;
        private string description;
        private string image;
        private string idBrand;
        private string idCategory;
        private int quantity;

        public Product() { }
        public Product(Guid guid, string name, int price, string description, string image, string idBrand, string idCategory, int quantity)
        {
            this.guid = guid;
            this.productName = name;
            this.price = price;
            this.description = description;
            this.image = image;
            this.idBrand = idBrand;
            this.idCategory = idCategory;
            this.Quantity = quantity;
        }
        
        public Guid Guid { get => guid; set => guid = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public string IdBrand { get => idBrand; set => idBrand = value; }
        public string IdCategory { get => idCategory; set => idCategory = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public void Update()
        {
            try
            {
                SqlConnection conn = new SqlConnection("");
                SqlConnection db = null; //connection string here
                db.Open();

                string statement = "UPDATE `product` SET `productName`=@productName, `price`=@price, `description`=@description, `image`=@image,`idBrand`=@idBrand, `idCategory`=@idCategory, `quantity` =@quantity where `guid`=@guid";
                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@guid", this.Guid);
                command.Parameters.AddWithValue("@productName", this.productName);
                command.Parameters.AddWithValue("@price", this.price);
                command.Parameters.AddWithValue("@description", this.description);
                command.Parameters.AddWithValue("@image", this.image);
                command.Parameters.AddWithValue("@idBrand", this.idBrand);
                command.Parameters.AddWithValue("@idCategory", this.idCategory);
                command.Parameters.AddWithValue("@quantity", this.quantity);
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Error occured updateing Students to the data source.", e);
            }
        }
        public void Delete()
        {
            try
            {
                SqlConnection conn = new SqlConnection("");
                SqlConnection db = null; //connection string here
                db.Open();

                string statement = "Deelete `product` where `guid`=@guid";
                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@guid", this.Guid);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured updateing Students to the data source.", e);
            }
        }
        public void Insert()
        {
            try
            {
                SqlConnection conn = new SqlConnection("");
                SqlConnection db = null; //connection string here
                db.Open();

                string statement = "INSERT INTO `students`(guid,productName,price, description, image, idBrand, idCategory, quantity) values(@guid,@productName,@price, @description, @image, @idBrand, @idCategory, @quantity)";
                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@guid", this.Guid);
                command.Parameters.AddWithValue("@productName", this.productName);
                command.Parameters.AddWithValue("@price", this.price);
                command.Parameters.AddWithValue("@description", this.description);
                command.Parameters.AddWithValue("@image", this.image);
                command.Parameters.AddWithValue("@idCategory", this.idCategory);
                command.Parameters.AddWithValue("@idBrand", this.idBrand);
                command.Parameters.AddWithValue("@quantity", this.quantity);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured inserting Students to the data source.", e);
            }
        }

        public Product FindByGuId()
        {

            try
            {
                SqlConnection conn = new SqlConnection("");
                conn.Open();

                string statement = "SELECT * FROM `product` where `guid`=@guid";

                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@guid", this.guid);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new(command);

                DataTable dataTable = new();
                adapter.Fill(dataTable);

                Guid guid = Guid.Parse(dataTable.Rows[0].ItemArray[0].ToString());
                string productName = dataTable.Rows[0].ItemArray[1].ToString();
                int price = int.Parse(dataTable.Rows[0].ItemArray[2].ToString());
                string description = dataTable.Rows[0].ItemArray[3].ToString();
                string image = dataTable.Rows[0].ItemArray[4].ToString();
                string idBrand = dataTable.Rows[0].ItemArray[5].ToString();
                string idCategory = dataTable.Rows[0].ItemArray[6].ToString();
                int quantity = int.Parse(dataTable.Rows[0].ItemArray[7].ToString());

                Product product = new Product(guid, productName, price, description, image, idBrand, idCategory, quantity);
                return product;
            }
            catch (Exception e)
            {
                throw new Exception("Error occured reading Product from the data source.", e);
            }
        }

        //logic 
        public float calculatorVAT(float persent)
        {
            return this.price * persent;
        }
        public bool checkQuantity()
        {
            return quantity > 0;
        }
    }
}
