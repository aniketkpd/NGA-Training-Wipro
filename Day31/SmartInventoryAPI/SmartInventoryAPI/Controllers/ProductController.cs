using Microsoft.AspNetCore.Mvc;
using SmartInventoryAPI.Models;

namespace SmartInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        // Creating product list
        private static List<Products> products = new List<Products>()
        {
            new Products { Id = 1, Name = "Laptop", Price = 50000, Quantity = 5 },
            new Products { Id = 2, Name = "Mobile", Price = 10000, Quantity = 10 },
            new Products { Id = 3, Name = "TV", Price = 20000, Quantity = 2 }
        };

        // GET: api/products
        [HttpGet]
        public ActionResult<List<Products>> GetAllProducts()
        {
            return Ok(products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public ActionResult<Products> GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public ActionResult<Products> CreateProduct(Products product)
        {
            products.Add(product);

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = product.Id },
                product
            );
        }




        // PUT: api/products/1
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Products updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;

            return Ok(product);
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);

            return Ok("Product deleted successfully");
        }
    }
}