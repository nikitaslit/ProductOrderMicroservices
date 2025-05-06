using Microsoft.AspNetCore.Mvc;
using ProductService.Model;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/product")]  // Убираем {id} из Route и добавляем параметр к методу
    public class ProductController : ControllerBase
    {
        private readonly ProductManagementService.ProductManagementService _productService;

        // Конструктор для внедрения зависимостей
        public ProductController(ProductManagementService.ProductManagementService productService)
        {
            _productService = productService;
        }

        // GET /api/product/{id} - Получить продукт по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProductsAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST /api/product - Добавить новый продукт
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT /api/product/{id}/stock - Обновить количество на складе
        [HttpPut("{id}/stock")]
        public async Task<IActionResult> UpdateProductStock(int id, [FromBody] int stock)
        {
            await _productService.UpdateProductAsync(id, stock);
            return NoContent();
        }
    }
}