using ProductCommon;
using ProductStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace ProductRepository
{
    public class Data : IProductRepository
    {
        private Catalogue _catalogue;
        public Data()
        {
            _catalogue = Catalogue.GetInstance();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _catalogue.GetProducts();
        }

        public Product GetProduct(int productId)
        {
            return _catalogue.GetProduct(productId);
        }

        public Product AddProduct(Product product)
        {
            return _catalogue.AddProduct(product);
        }

        public Product UpdateProduct(Product product)
        {
            return _catalogue.UpdateProduct(product);
        }

        public bool DeleteProduct(int productId)
        {
            return _catalogue.DeleteProduct(productId);
        }
    }
}
