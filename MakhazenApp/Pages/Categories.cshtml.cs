using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Makhazen.Models;

public class CategoriesModel : PageModel
{
    private readonly IInventoryService _inv;
    public CategoriesModel(IInventoryService inv) { _inv = inv; }

    [BindProperty]
    public string NewCategory { get; set; } = string.Empty;

    public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();

    public void OnGet() => Categories = _inv.GetCategories();

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(NewCategory))
        {
            ModelState.AddModelError(string.Empty, "Category name required");
            Categories = _inv.GetCategories();
            return Page();
        }
        _inv.AddCategory(NewCategory.Trim());
        return RedirectToPage();
    }

    public int GetCount(string category) => _inv.GetProducts().Count(p => p.Category == category);
}
