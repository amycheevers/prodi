using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prodi.Models;

namespace prodi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        readonly ApiContext _context;

        public ProductsController(ApiContext context)
        {
            _context = context;
        }

        // GET api/products
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string description,
                                             [FromQuery]string model,
                                             [FromQuery]string brand)
        {
            var products = await _context.Products.ToArrayAsync();

            var response = products.Where(p => (description == null ? true : p.Description == description)
                                          && (model == null ? true : p.Model == model)
                                          && (brand == null ? true : p.Brand == brand))
                                   .Select(p => new
                                   {
                                       id = p.Id,
                                       description = p.Description,
                                       model = p.Model,
                                       brand = p.Brand
                                   });

            if (response.Any())
            {
                return Ok(response);
            }
            return NotFound();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var products = await _context.Products.ToArrayAsync();

            try
            {
                var response = products.First(p => p.Id == id);
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            var products = await _context.Products.ToArrayAsync();

            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Product product)
        {
            var products = await _context.Products.ToArrayAsync();

            try
            {
                var productToUpdate = products.First(p => p.Id == id);
                _context.Products.Update(productToUpdate);
                productToUpdate.Description = product.Description;
                productToUpdate.Model = product.Model;
                productToUpdate.Brand = product.Brand;
                _context.SaveChanges();

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var products = await _context.Products.ToArrayAsync();

            try
            {
                var product = products.First(p => p.Id == id);
                _context.Products.Remove(product);
                _context.SaveChanges();

                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}