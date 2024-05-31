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
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProduct()
        {
            var products = await productService.GetAll();
            var productDtos = products
                .Select(ProductDto.FromEntity);

            return Ok(productDtos);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            var dto = ProductDto.FromEntity(product);
            return Ok(dto);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto product)
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

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto createProduct)
        {
            var product = CreateProductDto.ToEntity(createProduct);
            await productService.Add(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
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

