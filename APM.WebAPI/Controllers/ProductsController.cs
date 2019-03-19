using APM.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System;

namespace APM.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        static Product productRepositry = new ProductRepository();
        // GET: api/Products
        public IEnumerable<Product> Get()
        {
          var productRepositry = new ProductRepository();
          return new string[] { "value1", "value2" };
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
