using ProductCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductService.Controllers
{
    //
    public class ProductsController : ApiController
    {
        private IProductProvider _productProvider;
        public ProductsController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            IEnumerable<Product> products = _productProvider.GetProducts();
            if (products != null)
            {
                return Ok<IEnumerable<Product>>(products);
            }

            return NotFound();
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            Product product = _productProvider.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok<Product>(product);
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Product product)
        {
            HttpResponseMessage response;
            if (product == null ||string.IsNullOrWhiteSpace(product.ProductName))
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Null product or empty product name";
            }
            else
            {
                product = _productProvider.AddProduct(product);
                response = Request.CreateResponse(HttpStatusCode.Created, product);
            }

            return response;
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Product product)
        {
            HttpResponseMessage response;
            if (product == null || product.ProductId <= 0 || string.IsNullOrWhiteSpace(product.ProductName))
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Invalid product or empty product name";
            }
            else
            {
                product = _productProvider.UpdateProduct(product);
                response = Request.CreateResponse(HttpStatusCode.OK, product);
            }

            return response;
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
            if (id <= 0)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Invalid product";
            }
            else
            {
                _productProvider.DeleteProduct(id);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }

            return response;
        }
    }
}
