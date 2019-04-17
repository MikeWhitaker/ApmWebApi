using APM.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using System.Web.Http.Description; //Add support for the responce type of the http

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
    [ResponseType(typeof(Product))]
    public IQueryable<Product> Get()
    {
      try
      {
        var fullListOfProducts = productRepositry.Retrieve();
        var queryableReturnObject = fullListOfProducts.AsQueryable();

        return queryableReturnObject;
      }
      catch (Exception ex)
      {
        return (System.Linq.IQueryable<APM.WebAPI.Models.Product>) InternalServerError(ex);
      }
    }

    //GET: api/Products/5
    public IHttpActionResult Get(int id)
    {
      try
      {
        if (id == 0) // id is 0 so gererate a new product.
        {
          var newProductItem = productRepositry.Create();
          return Ok<Product>(newProductItem);
        }

        // id is given so lookup the item in the repository.
        var productList = productRepositry.Retrieve();
        var queriedProduct = productList.FirstOrDefault(s => s.ProductId == id);
        if (queriedProduct == null)
        {
          return BadRequest();
        }

        return Ok(queriedProduct);
      } catch (Exception ex)
      {
        return (System.Linq.IQueryable<APM.WebAPI.Models.Product>)InternalServerError(ex);
      }
    }

    // POST: api/Products
    public IHttpActionResult Post([FromBody]Product product)
    {
      if (product == null)
      {
        return BadRequest();
      }

      var createdProduct = productRepositry.Save(product);
      if(createdProduct == null)
      {
        return Conflict();
      }

      return Created<Product>(Request.RequestUri + createdProduct.ProductId.ToString(), createdProduct);
    }

    // PUT: api/Products/5
    public IHttpActionResult Put(int id, [FromBody]Product product)
    {
      if(product == null)
      {
        return BadRequest();
      }

      var updatedProduct = productRepositry.Save(id, product);
      if(updatedProduct == null)
      {
        return Conflict();
      }
      return Ok();
    }

    // DELETE: api/Products/5
    public void Delete(int id)
    {
    }
  }
}
