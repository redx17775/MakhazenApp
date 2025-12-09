using Microsoft.AspNetCore.Mvc;
using Makhazen.Models;
using Microsoft.Data.SqlClient;
using System.Data;
//backend=----
[ApiController]
[Route("api/[controller]")]
public class ProductApiController : ControllerBase
{
    private readonly IConfiguration _config;
    public ProductApiController(IConfiguration config) { _config = config; }

    private string GetConn() => _config.GetConnectionString("DefaultConnection");

    [HttpGet]
    public IActionResult GetAll()
    {
        var list = new List<Product>();
        try
        {
            using var conn = new SqlConnection(GetConn());
            using var cmd = new SqlCommand("SELECT ProductID, ProductName, ItemCode, Price, Quantity, ImageURL, (SELECT CategoryName FROM Category WHERE CategoryID = p.CategoryID) AS CategoryName FROM Product p", conn);
            conn.Open();
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new Product
                {
                    Id = r.GetInt32(0),
                    Name = r.GetString(1),
                    Code = r.GetString(2),
                    Price = r.GetDecimal(3),
                    Stock = r.GetInt32(4),
                    PhotoUrl = r.IsDBNull(5) ? null : r.GetString(5),
                    Category = r.IsDBNull(6) ? string.Empty : r.GetString(6)
                });
            }
            return Ok(list);
        }
        catch (Exception ex) { return StatusCode(500, new { error = ex.Message }); }
    }

    [HttpGet("{code}")]
    public IActionResult GetByCode(string code)
    {
        try
        {
            using var conn = new SqlConnection(GetConn());
            using var cmd = new SqlCommand("SELECT ProductID, ProductName, ItemCode, Price, Quantity, ImageURL, (SELECT CategoryName FROM Category WHERE CategoryID = p.CategoryID) AS CategoryName FROM Product p WHERE ItemCode = @code", conn);
            cmd.Parameters.AddWithValue("@code", code);
            conn.Open();
            using var r = cmd.ExecuteReader();
            if (!r.Read()) return NotFound();
            var p = new Product
            {
                Id = r.GetInt32(0),
                Name = r.GetString(1),
                Code = r.GetString(2),
                Price = r.GetDecimal(3),
                Stock = r.GetInt32(4),
                PhotoUrl = r.IsDBNull(5) ? null : r.GetString(5),
                Category = r.IsDBNull(6) ? string.Empty : r.GetString(6)
            };
            return Ok(p);
        }
        catch (Exception ex) { return StatusCode(500, new { error = ex.Message }); }
    }

    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
        if (product is null) return BadRequest("Product required");
        if (string.IsNullOrWhiteSpace(product.Name) || string.IsNullOrWhiteSpace(product.Code))
            return BadRequest("Name and Code required");
        try
        {
            using var conn = new SqlConnection(GetConn());
            using var cmd = new SqlCommand(@"INSERT INTO Product (ProductName, ItemCode, CategoryID, Quantity, Price, ImageURL, Status)
                                            VALUES (@name,@code,@catId,@stock,@price,@photo,@status);
                                            SELECT CAST(SCOPE_IDENTITY() as int);", conn);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@code", product.Code);
            cmd.Parameters.AddWithValue("@catId", product.CategoryId == 0 ? (object)DBNull.Value : product.CategoryId);
            cmd.Parameters.AddWithValue("@stock", product.Stock);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@photo", (object)product.PhotoUrl ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@status", string.IsNullOrWhiteSpace(product.Status) ? "InStock" : product.Status);
            conn.Open();
            var id = (int)cmd.ExecuteScalar();
            product.Id = id;
            return CreatedAtAction(nameof(GetByCode), new { code = product.Code }, product);
        }
        catch (SqlException ex) { return BadRequest(new { error = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { error = ex.Message }); }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Product product)
    {
        if (product is null) return BadRequest("Product required");
        try
        {
            using var conn = new SqlConnection(GetConn());
            using var cmd = new SqlCommand(@"UPDATE Product SET ProductName=@name, ItemCode=@code, CategoryID=@catId, Quantity=@stock, Price=@price, ImageURL=@photo, Status=@status WHERE ProductID=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@code", product.Code);
            cmd.Parameters.AddWithValue("@catId", product.CategoryId == 0 ? (object)DBNull.Value : product.CategoryId);
            cmd.Parameters.AddWithValue("@stock", product.Stock);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@photo", (object)product.PhotoUrl ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@status", string.IsNullOrWhiteSpace(product.Status) ? "InStock" : product.Status);
            conn.Open();
            var rows = cmd.ExecuteNonQuery();
            if (rows == 0) return NotFound();
            return NoContent();
        }
        catch (SqlException ex) { return BadRequest(new { error = ex.Message }); }
        catch (Exception ex) { return StatusCode(500, new { error = ex.Message }); }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            using var conn = new SqlConnection(GetConn());
            using var cmd = new SqlCommand("DELETE FROM Product WHERE ProductID=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            var rows = cmd.ExecuteNonQuery();
            if (rows == 0) return NotFound();
            return NoContent();
        }
        catch (Exception ex) { return StatusCode(500, new { error = ex.Message }); }
    }
}
