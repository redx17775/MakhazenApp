using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Makhazen.Models;
using MakhazenApp.Data;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous] // Allow remote access without authentication
public class ProductApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/ProductApi
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var products = (from p in _context.Product
                          join c in _context.Category on p.CategoryId equals c.Id into categoryGroup
                          from cat in categoryGroup.DefaultIfEmpty()
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
                              Category = cat != null ? cat.Name : string.Empty
                          }).ToList();

            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // GET: api/ProductApi/{id}
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var product = (from p in _context.Product
                          where p.Id == id
                          join c in _context.Category on p.CategoryId equals c.Id into categoryGroup
                          from cat in categoryGroup.DefaultIfEmpty()
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
                              Category = cat != null ? cat.Name : string.Empty
                          }).FirstOrDefault();

            if (product == null) return NotFound();
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // GET: api/ProductApi/code/{code}
    [HttpGet("code/{code}")]
    public IActionResult GetByCode(string code)
    {
        try
        {
            var product = (from p in _context.Product
                          where p.Code == code
                          join c in _context.Category on p.CategoryId equals c.Id into categoryGroup
                          from cat in categoryGroup.DefaultIfEmpty()
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
                              Category = cat != null ? cat.Name : string.Empty
                          }).FirstOrDefault();

            if (product == null) return NotFound();
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // GET: api/ProductApi/search?name={name}&category={category}
    [HttpGet("search")]
    public IActionResult Search([FromQuery] string? name = null, [FromQuery] string? category = null)
    {
        try
        {
            var query = from p in _context.Product
                       join c in _context.Category on p.CategoryId equals c.Id into categoryGroup
                       from cat in categoryGroup.DefaultIfEmpty()
                       where (string.IsNullOrEmpty(name) || p.Name.Contains(name))
                          && (string.IsNullOrEmpty(category) || (cat != null && cat.Name.Contains(category)))
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
                           Category = cat != null ? cat.Name : string.Empty
                       };

            var products = query.ToList();
            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // POST: api/ProductApi
    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        if (product == null) return BadRequest("Product required");

        try
        {
            // Set default status if not provided
            if (string.IsNullOrWhiteSpace(product.Status))
            {
                product.Status = "InStock";
            }

            _context.Product.Add(product);
            _context.SaveChanges();

            // Load category name for response
            if (product.CategoryId > 0)
            {
                var category = _context.Category.Find(product.CategoryId);
                if (category != null)
                {
                    product.Category = category.Name;
                }
            }

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // PUT: api/ProductApi/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Product updatedProduct)
    {
        if (updatedProduct == null) return BadRequest("Product required");

        try
        {
            var product = _context.Product.Find(id);
            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Code = updatedProduct.Code;
            product.CategoryId = updatedProduct.CategoryId;
            product.Stock = updatedProduct.Stock;
            product.Price = updatedProduct.Price;
            product.PhotoUrl = updatedProduct.PhotoUrl;
            product.Status = updatedProduct.Status;

            _context.SaveChanges();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    // DELETE: api/ProductApi/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var product = _context.Product.Find(id);
            if (product == null) return NotFound();

            _context.Product.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}
