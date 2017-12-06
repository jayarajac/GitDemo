using ProductCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProvider
{
    public class Business : IProductProvider
    {
        private IProductRepository _repository;
        public Business(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repository.GetProducts();
        }

        public Product GetProduct(int productId)
        {
            return _repository.GetProduct(productId);
        }

        public Product AddProduct(Product product)
        {
            return _repository.AddProduct(product);
        }

        public Product UpdateProduct(Product product)
        {
            return _repository.UpdateProduct(product);
        }

        public bool DeleteProduct(int productId)
        {
           return _repository.DeleteProduct(productId);
        }
    }
}
