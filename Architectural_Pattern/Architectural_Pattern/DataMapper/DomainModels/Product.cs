using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architectural_Pattern.DataMapper.DomainModels
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

        public Guid Guid { get => guid; set => guid = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public string IdBrand { get => idBrand; set => idBrand = value; }
        public string IdCategory { get => idCategory; set => idCategory = value; }

        public Product()
        {
            this.Guid = Guid.NewGuid();
        }

        public Product(Guid guid)
        {
            this.Guid = guid;
        }
    }
}
