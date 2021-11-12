using System;
using Architectural_Pattern.RowDataGateway.TechnicalServices;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architectural_Pattern.RowDataGateway.DomainLayer
{
    class Product
    {
        private ProductGateway data;
        public Product(ProductGateway data)
        {
            this.data = data;
        }
        public string GetProductName()
        {
            return data.ProductName;
        }
        public Guid GetGuid()
        {
            return data.Guid;
        }
        public int GetPrice()
        {
            return data.Price;
        }
        public string GetDescription()
        {
            return data.Description;
        }
        public string GetImage()
        {
            return data.Image;
        }
        public string GetIdBrand()
        {
            return data.IdBrand;
        }
        public string GetIdCategory()
        {
            return data.IdCategory;
        }
        public float GetVAT()
        {
            return (float)(data.Price * 0.1);
        }
    }
}
