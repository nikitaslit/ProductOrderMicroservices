namespace OrderService.Model;

public class Order
{
    public int Id { get; set; }
    public int Stock { get; set; }
    public bool IsProductAvailable { get; set; }
}
public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Stock { get; set; }
}