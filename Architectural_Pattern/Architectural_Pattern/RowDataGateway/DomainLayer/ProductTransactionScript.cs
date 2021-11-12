using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architectural_Pattern.RowDataGateway.TechnicalServices;

namespace Architectural_Pattern.RowDataGateway.DomainLayer
{
    class ProductTransactionScript
    {
        public StringBuilder GetAllProduct()
        {
            ProductFinder finder = new ProductFinder();
            List<ProductGateway> products = finder.FindProducts();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < products.Count; i++)
            {
                Product product = new Product(products[i]);
                result.Append(product.GetProductName());
                result.Append(" ");
                result.Append(product.GetDescription());
                result.Append(" ");
                result.Append(product.GetPrice());
                result.Append(" ");
                result.Append(product.GetImage());
                result.Append(" ");
                result.Append(product.GetVAT());
                result.Append(";\n");
            }
            return result;
        }
    }
}
