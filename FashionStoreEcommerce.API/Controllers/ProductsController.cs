using FashionStoreEcommerce.Core.Application.Products;
using FashionStoreEcommerce.Core.Application.Products.Services;
using FashionStoreEcommerce.Core.Domain.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionStoreEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetCategory()
        {
            var products = await productService.GetAll();
            var productDtos = products
                .Select(ProductDto.FromEntity);

            return Ok(productDtos);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetCategory(int id)
        {
            var product = await productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            var dto = ProductDto.FromEntity(product);
            return Ok(dto);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, ProductDto product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var entity = ProductDto.ToEntity(product);
            var result = await productService.Update(entity);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto createProduct)
        {
            var product = CreateProductDto.ToEntity(createProduct);
            await productService.Add(product);

            return CreatedAtAction("GetCategory", new { id = product.Id }, product);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await productService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

