using FashionStoreEcommerce.Core.Application.Products;
using FashionStoreEcommerce.Core.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace FashionStoreEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategory()
        {
            var categories = await categoryService.GetAll();
            var categoryDtos = categories
                .Select(CategoryDto.FromEntity);

            return Ok(categoryDtos);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            var dto = CategoryDto.FromEntity(category);
            return Ok(dto);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var entity = CategoryDto.ToEntity(category);
            var result = await categoryService.Update(entity);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CreateCategoryDto createCategory)
        {
            var category = CreateCategoryDto.ToEntity(createCategory);
            await categoryService.Add(category);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await categoryService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
