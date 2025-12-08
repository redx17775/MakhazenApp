// Makhazen/Services/IInventoryService.cs
using Makhazen.Models;
public interface IInventoryService
{
    IEnumerable<Product> GetProducts();
    Product AddProduct(Product p);
    IEnumerable<Category> GetCategories();
    Category AddCategory(string name);
    IEnumerable<Order> GetOrders();
    Order AddOrder(Order o);
    Product? GetByCode(string code);
}
