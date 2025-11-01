// Makhazen/Services/InventoryService.cs
using Makhazen.Models;
public class InventoryService : IInventoryService
{
    private readonly List<Product> _products;
    private readonly List<Category> _categories;
    private readonly List<Order> _orders;

    public InventoryService()
    {
        _categories = new List<Category>
        {
            new() { Id = 1, Name = "T-Shirts" },
            new() { Id = 2, Name = "Bottoms" },
            new() { Id = 3, Name = "Accessories" }
        };

        _products = new List<Product>
        {
            new() { Id = 1, Name = "Unisex T-Shirt White", Code = "TSH-001", Category = "T-Shirts", Stock = 10, Price = 15.5M },
            new() { Id = 2, Name = "Denim Shorts", Code = "SH-010", Category = "Bottoms", Stock = 5, Price = 29.99M }
        };

        _orders = new List<Order>();
    }

    public IEnumerable<Product> GetProducts() => _products;
    public Product AddProduct(Product p)
    {
        // simple business rule example
        if (string.IsNullOrWhiteSpace(p.Name)) throw new ArgumentException("Product name required");
        p.Id = _products.Count + 1;
        _products.Add(p);
        return p;
    }
    public IEnumerable<Category> GetCategories() => _categories;
    public Category AddCategory(string name)
    {
        var c = new Category { Id = _categories.Count + 1, Name = name };
        _categories.Add(c);
        return c;
    }
    public IEnumerable<Order> GetOrders() => _orders;
    public Order AddOrder(Order o) { o.Id = _orders.Count + 1; _orders.Add(o); return o; }
    public Product? GetByCode(string code) => _products.FirstOrDefault(p => p.Code == code);
}
