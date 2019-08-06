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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;

        public ProductController(IProductService productService, IProductRepository productRepository)
        {
            _productService = productService;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Index()
        {
            return await _productRepository.GetProductsAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute]int id)
        {
            var product = await _productService.GetAllProductItems(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("ProductByCategoryId/{id}")]
        public async Task<IEnumerable<Product>> GetProdcutByCategoryId([FromRoute]int id)
        {
            return await _productRepository.GetProductsByCategoryId(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            return Ok(await _productService.AddProductAsync(product));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _productService.SetProductAsync(product));
        }

        [HttpGet("ProductByName/{name}")]
        public async Task<IActionResult> GetProductByName([FromRoute]string name)
        {
            var product = await _productRepository.GetProductByName(name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdcut([FromRoute] int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(await _productService.DeleteProductAsync(product)); 
        }

    }
}