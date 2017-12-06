using ProductCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStorage
{
    public class Catalogue : IProductRepository
    {
        private static readonly Catalogue catalogue = new Catalogue();
        private List<Product> products = new List<Product>();
        private Catalogue()
        {
            products.Add(new Product() { ProductId = 1, ProductName = "Apple" });
            products.Add(new Product() { ProductId = 2, ProductName = "Orange" });
            products.Add(new Product() { ProductId = 3, ProductName = "Mango" });
            products.Add(new Product() { ProductId = 4, ProductName = "Grape" });

        }

        public static Catalogue GetInstance()
        {
            return catalogue;
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public Product GetProduct(int productId)
        {
            return products.Where(x => x.ProductId == productId).FirstOrDefault();
        }

        public Product AddProduct(Product product)
        {
            Product lastProduct = products.OrderByDescending(x => x.ProductId).FirstOrDefault();
            product.ProductId = lastProduct == null ? 0 : lastProduct.ProductId + 1;
            products.Add(product);
            return products.Find(x => x.ProductId == product.ProductId);
        }

        public Product UpdateProduct(Product product)
        {
            Product existingProduct = products.Find(x => x.ProductId == product.ProductId);
            existingProduct.ProductName = product.ProductName;
            return products.Find(x => x.ProductId == product.ProductId);
        }

        public bool DeleteProduct(int productId)
        {
            bool isSuccess = false;
            Product product = products.Find(x => x.ProductId == productId);
            if(product != null)
            {
                products.Remove(product);
                isSuccess = true;
            }

            return isSuccess;
        }
    }
}
