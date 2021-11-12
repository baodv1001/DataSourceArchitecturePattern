using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architectural_Pattern.RowDataGateway.TechnicalServices
{
    class ProductGateway
    {
        private Guid guid; // Note that unique ID is read-only!
        private string productName;
        private int price;
        private string description;
        private string image;
        private string idBrand;
        private string idCategory;

        public Guid Guid { get => guid; set => guid = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public string IdBrand { get => idBrand; set => idBrand = value; }
        public string IdCategory { get => idCategory; set => idCategory = value; }

        public ProductGateway()
        {
            this.Guid = Guid.NewGuid();
        }

        public ProductGateway(Guid guid)
        {
            this.Guid = guid;
        }



        public void Update()
        {
            try
            {
                SqlConnection conn = new SqlConnection("");
                SqlConnection db = null; //connection string here
                db.Open();

                string statement = "UPDATE `product` SET `productName`=@productName, `price`=@price, `description`=@description, `image`=@image,`idBrand`=@idBrand, `idCategory`=@idCategory where `guid`=@guid";
                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@productName", this.productName);
                command.Parameters.AddWithValue("@price", this.price);
                command.Parameters.AddWithValue("@description", this.description);
                command.Parameters.AddWithValue("@image", this.image);
                command.Parameters.AddWithValue("@idCategory", this.idCategory);
                command.Parameters.AddWithValue("@idBrand", this.idBrand);

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

                string statement = "INSERT INTO `students`(guid,productName,price, description, image, idBrand, idCategory) values(@guid,@productName,@price, @description, @image, @idBrand, @idCategory)";
                SqlCommand command = new(statement, conn);
                command.Parameters.AddWithValue("@productName", this.productName);
                command.Parameters.AddWithValue("@price", this.price);
                command.Parameters.AddWithValue("@description", this.description);
                command.Parameters.AddWithValue("@image", this.image);
                command.Parameters.AddWithValue("@idCategory", this.idCategory);
                command.Parameters.AddWithValue("@idBrand", this.idBrand);

                command.Parameters.AddWithValue("@guid", this.Guid);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error occured inserting Students to the data source.", e);
            }
        }
    }
}
