using APM.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System;
using System.Web.Http.Cors;
using System.Web.Http.OData;

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
    [EnableQuery]
    public IQueryable<Product> Get()
    {
      var fullListOfProducts = productRepositry.Retrieve();
      var queryableReturnObject = fullListOfProducts.AsQueryable(); 
      return queryableReturnObject;
    }

    //GET: api/Products/5
    public Product Get(int id)
    {
      if(id == 0) // id is 0 so gererate a new product.
      {
        var newProductItem = productRepositry.Create();
        return newProductItem;
      }

      // id is given so lookup the item in the repository.
      var productList = productRepositry.Retrieve();
      var queriedProduct = productList.FirstOrDefault(s => s.ProductId == id); //should be safe, as it should return only one item.
      return queriedProduct;
    }

    // POST: api/Products
    public void Post([FromBody]Product product)
    {
      var createdProduct = productRepositry.Save(product);
    }

    // PUT: api/Products/5
    public void Put(int id, [FromBody]Product product)
    {
      var updatedProduct = productRepositry.Save(id, product);
    }

    // DELETE: api/Products/5
    public void Delete(int id)
    {
    }
  }
}
