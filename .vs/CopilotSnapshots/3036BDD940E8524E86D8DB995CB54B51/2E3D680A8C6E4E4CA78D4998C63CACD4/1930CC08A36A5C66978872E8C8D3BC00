using Microsoft.AspNetCore.Mvc;
using Makhazen.Models;

[ApiController]
[Route("api/[controller]")]
public class ProductApiController : ControllerBase
{
    private readonly IInventoryService _inv;
    public ProductApiController(IInventoryService inv) { _inv = inv; }

    [HttpGet]
    public IActionResult GetAll() => Ok(_inv.GetProducts());

    [HttpGet("{code}")]
    public IActionResult GetByCode(string code)
    {
        var p = _inv.GetByCode(code);
        return p is null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        try
        {
            var created = _inv.AddProduct(product);
            return CreatedAtAction(nameof(GetByCode), new { code = created.Code }, created);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "Server error" });
        }
    }
}
