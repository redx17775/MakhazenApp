using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Makhazen.Models;

public class AddProductModel : PageModel
{
    private readonly IInventoryService _inv;
    public AddProductModel(IInventoryService inv) { _inv = inv; }

    [BindProperty]
    public Product Product { get; set; } = new();

    public IEnumerable<Category> Categories => _inv.GetCategories();
    public string? Message { get; set; }
    public string? ErrorMessage { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        try
        {
            if (!ModelState.IsValid) return Page();

            _inv.AddProduct(Product);
            Message = "Product added successfully";
            return RedirectToPage("/Products");
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            ErrorMessage = ex.Message;
            return Page();
        }
        catch (Exception ex)
        {
            ErrorMessage = "Unexpected server error: " + ex.Message;
            return Page();
        }
    }
}
