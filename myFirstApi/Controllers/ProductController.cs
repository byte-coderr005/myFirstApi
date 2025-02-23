using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using myFirstApi.Models;
using System.Security.Cryptography.X509Certificates;

namespace myFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new()
        {
            new Product { Id = 1, Name ="Laptop", Price = 1500},
            new Product { Id = 2, Name ="Mouse", Price = 50}
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id) {
            var product = products.FirstOrDefault(x => x.Id == id);
            return product != null ? Ok(product) : NotFound();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product) {
            {
                products.Add(product);
                return Ok(product);
            }
            [HttpPut("{id}")]
         ActionResult UpdateProduct(int id, Product updatedProduct)
            {
                var product = products.FirstOrDefault(p => p.Id == id);
                if (product is null) return NotFound();

                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                return Ok(product);
            }
            [HttpDelete("{id}")]
            ActionResult DeleteProduct(int id)
            {
                var product = products.FirstOrDefault(p => p.Id == id);
                if (product is null) return NotFound();

                products.Remove(product);
                return Ok();
            }
        }
    }
    }

