using Microsoft.AspNetCore.Mvc;
using OrderService.Context;
using OrderService.Model;
using OrderService.Service;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly OrderManagementService _orderManagementService;

        public OrderController(OrderManagementService orderManagementService)
        {
            _orderManagementService = orderManagementService;
        }

        // POST /api/order - Создать заказ
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(int productId, int quantity)
        {
            var order = await _orderManagementService.CreateOrderAsync(productId, quantity);

            if (order == null)
            {
                return BadRequest("Продукт недоступен или недостаточно товара на складе.");
            }

            return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
        }

        // GET /api/order/{id} - Получить информацию о заказе по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderManagementService.GetOrderAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}