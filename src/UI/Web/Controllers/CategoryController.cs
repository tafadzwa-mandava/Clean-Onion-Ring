using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(
            IProductService entryService,
            ICategoryService categoryService,
            ICategoryRepository categoryRepository)
        {
            _productService = entryService;
            _categoryService = categoryService;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Index()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category = await _categoryService.GetAllCategoryItems(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            category = await _categoryService.AddCategoryAsync(category);
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            await _categoryService.SetCategoryAsync(category);
            return Ok();
        }

        [HttpGet("CategoryByName/{name}")]
        public async Task<IActionResult> GetCategoryByName([FromRoute]string name)
        {
            var category = await _categoryRepository.GetCategoryByName(name);

            if (category == null)       
                return NotFound();
           
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
                return NotFound();

            return Ok(await _categoryService.DeleteCategoryAsync(category));
        }
    }
}