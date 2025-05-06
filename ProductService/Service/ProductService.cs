using Microsoft.EntityFrameworkCore;
using ProductService.Context;
using ProductService.Model;

namespace ProductService.ProductManagementService;

public class ProductManagementService
{
    private readonly ProductDbContext _context;

    public ProductManagementService(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProductsAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(int id, int Stock)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            product.Stock = Stock;
            await _context.SaveChangesAsync();
        }
    }
}