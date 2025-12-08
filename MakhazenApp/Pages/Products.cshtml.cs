using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Makhazen.Models;
using MakhazenApp.Data;
using Microsoft.EntityFrameworkCore;

public class ProductsModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public ProductsModel(ApplicationDbContext db) { _db = db; }

    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
    public string? ErrorMessage { get; set; }

    // Use EF Core with LINQ method syntax
    public void OnGet()
    {
        try
        {
            // load categories into dictionary to map names without complex SQL
            var categories = _db.Category.AsNoTracking().ToDictionary(c => c.Id, c => c.Name);

            // simple EF load of products (uses attribute mappings)
            var list = _db.Product.AsNoTracking().ToList();
            foreach (var p in list)
            {
                p.Category = categories.TryGetValue(p.CategoryId, out var name) ? name : string.Empty;
            }
            Products = list;
        }
        catch (Exception ex)
        {
            ErrorMessage = "Failed to load products: " + ex.Message;
        }
    }

    // Delete using EF Core (LINQ lambda)
    public IActionResult OnPostDelete(int id)
    {
        try
        {
            var prod = _db.Product.FirstOrDefault(p => p.Id == id);
            if (prod != null)
            {
                _db.Product.Remove(prod);
                _db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = "Failed to delete product: " + ex.Message;
        }
        return RedirectToPage();
    }
}
