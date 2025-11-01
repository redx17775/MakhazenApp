using Microsoft.AspNetCore.Mvc.RazorPages;
using Makhazen.Models;
public class ProductsModel : PageModel
{
    private readonly IInventoryService _inv;
    public ProductsModel(IInventoryService inv) { _inv = inv; }

    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
        try { Products = _inv.GetProducts(); }
        catch (Exception ex) { ErrorMessage = "Failed to load products: " + ex.Message; }
    }
}
