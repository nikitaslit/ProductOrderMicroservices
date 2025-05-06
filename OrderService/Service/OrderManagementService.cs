using OrderService.Context;
using OrderService.Model;
using System.Net.Http;

namespace OrderService.Service
{
    public class OrderManagementService
    {
        private readonly OrderDbContext _context;
        private readonly HttpClient _httpClient;

        public OrderManagementService(OrderDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<Order> CreateOrderAsync(int productId, int quantity)
        {
            // Проверяем API продукта через HttpClient с правильно настроенным BaseAddress
            var productResponse = await _httpClient.GetAsync($"api/product/{productId}");

            if (!productResponse.IsSuccessStatusCode)
            {
                return null; // Если продукт не найден или ошибка
            }

            var product = await productResponse.Content.ReadFromJsonAsync<Product>();
            if (product != null && product.Stock >= quantity)
            {
                var order = new Order()
                {
                    Id = productId,
                    Stock = quantity,
                    IsProductAvailable = true
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                await ReserveProductAsync(productId, quantity);
                return order;
            }

            return null; // Если товара недостаточно
        }

        private async Task ReserveProductAsync(int productId, int quantity)
        {
            // Можно добавить логику резервирования, если нужно
            var productResponse = await _httpClient.GetAsync($"api/product/{productId}");
            productResponse.EnsureSuccessStatusCode();
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }
    }
}