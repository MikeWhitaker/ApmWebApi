using APM.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System;
using System.Web.Http.Cors;

namespace APM.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:50527", "*", "*")]
    public class ProductsController : ApiController
    {
        private ProductRepository productRepositry;

        public ProductsController()
        {
            productRepositry = new ProductRepository();
        }

        
        // GET: api/Products
        public IEnumerable<Product> Get()
        {
          return productRepositry.Retrieve();
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
