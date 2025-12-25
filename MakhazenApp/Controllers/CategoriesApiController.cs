using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Makhazen.Models;
using MakhazenApp.Data;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous] // Allow remote access without authentication
public class CategoriesApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoriesApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/CategoriesApi
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var categories = (from c in _context.Category
                             orderby c.Name
                             select c).ToList();

            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // GET: api/CategoriesApi/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var category = _context.Category.Find(id);
            if (category == null) return NotFound();

            return Ok(category);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // GET: api/CategoriesApi/search?name={name}
    [HttpGet("search")]
    public IActionResult Search([FromQuery] string? name = null)
    {
        try
        {
            var query = _context.Category.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            var categories = query.OrderBy(c => c.Name).ToList();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // GET: api/CategoriesApi/{id}/products
    [HttpGet("{id}/products")]
    public IActionResult GetProductsByCategory(int id)
    {
        try
        {
            var category = _context.Category.Find(id);
            if (category == null) return NotFound(new { error = "Category not found" });

            var products = (from p in _context.Product
                          where p.CategoryId == id
                          select new Product
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Code = p.Code,
                              Price = p.Price,
                              Stock = p.Stock,
                              PhotoUrl = p.PhotoUrl,
                              CategoryId = p.CategoryId,
                              Status = p.Status,
                              Category = category.Name
                          }).ToList();

            return Ok(new { category = category, products = products, count = products.Count });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // POST: api/CategoriesApi
    [HttpPost]
    public IActionResult Create([FromBody] Category category)
    {
        if (category == null) return BadRequest("Category required");
        if (string.IsNullOrWhiteSpace(category.Name))
            return BadRequest("Category name is required");

        try
        {
            category.Name = category.Name.Trim();
            _context.Category.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // PUT: api/CategoriesApi/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Category updatedCategory)
    {
        if (updatedCategory == null) return BadRequest("Category required");
        if (string.IsNullOrWhiteSpace(updatedCategory.Name))
            return BadRequest("Category name is required");

        try
        {
            var category = _context.Category.Find(id);
            if (category == null) return NotFound();

            category.Name = updatedCategory.Name.Trim();
            _context.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // DELETE: api/CategoriesApi/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var category = _context.Category.Find(id);
            if (category == null) return NotFound();

            // Check if category has products
            var productCount = _context.Product.Count(p => p.CategoryId == id);
            if (productCount > 0)
            {
                return BadRequest(new { error = $"Cannot delete category. It has {productCount} product(s) associated with it." });
            }

            _context.Category.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}

