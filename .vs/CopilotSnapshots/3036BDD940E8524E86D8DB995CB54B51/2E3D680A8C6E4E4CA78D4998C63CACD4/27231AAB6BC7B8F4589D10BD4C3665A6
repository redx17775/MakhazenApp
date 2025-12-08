using Microsoft.AspNetCore.Mvc;
using Makhazen.Models;

namespace Makhazen.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    public static List<Product> Products = new()

    {
        new() { Id = 1, Name = "Laptop", Category = "Electronics", Stock = 10, Price = 500 },
        new() { Id = 2, Name = "Keyboard", Category = "Accessories", Stock = 25, Price = 20 }
    };

    [HttpGet]
    public IActionResult GetAll() => Ok(Products);

    [HttpPost]
    public IActionResult Add(Product p)
    {
        if (string.IsNullOrWhiteSpace(p.Name) || string.IsNullOrWhiteSpace(p.Category))
            return BadRequest("Product name and category are required.");

        p.Id = Products.Count + 1;
        Products.Add(p);
        return Ok(p);
    }
}
