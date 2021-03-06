using Microsoft.AspNetCore.Mvc;
using WebServer.Models;
using System.Linq;

namespace WebServer.Controllers {

    [Route("api/[controller]")]
    public class ProductsController : Controller {
        [HttpGet]
        public Product[] Get() {
            return FakeData.Products.Values.ToArray();
        }

        [HttpGet("{id}")] //[HttpGet("ByID/{id}")]
        public Product Get(int id) {
            if (FakeData.Products.ContainsKey(id))
                return FakeData.Products[id];
            else
                return null;
        }

        [HttpGet("price/{low}/{high}")]
        public Product[] Get(int low, int high) {
            var products = FakeData.Products.Values
            .Where(p => p.Price >= low && p.Price <= high).ToArray();
            return products;
        }

        [HttpPost]
        public Product Post([FromBody]Product product) {
            product.ID = FakeData.Products.Keys.Max() + 1;
            FakeData.Products.Add(product.ID, product);
            return product; // contains the new ID
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product product) {
            if (FakeData.Products.ContainsKey(id)) {
                var target = FakeData.Products[id];
                target.ID = product.ID;
                target.Name = product.Name;
                target.Price = product.Price;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            if (FakeData.Products.ContainsKey(id)) {
                FakeData.Products.Remove(id);
            }
        }
    }
}