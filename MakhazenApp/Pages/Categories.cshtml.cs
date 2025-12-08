using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Makhazen.Models;
using MakhazenApp.Data;
using Microsoft.EntityFrameworkCore;

public class CategoriesModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public CategoriesModel(ApplicationDbContext db) { _db = db; }

    [BindProperty]
    public string NewCategory { get; set; } = string.Empty;

    public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();

    // Use EF Core with LINQ query syntax
    public void OnGet()
    {
        try
        {
            var q = from c in _db.Category.AsNoTracking()
                    orderby c.Name
                    select c;
            Categories = q.ToList();
        }
        catch (Exception)
        {
            Categories = Enumerable.Empty<Category>();
        }
    }

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(NewCategory))
        {
            ModelState.AddModelError(string.Empty, "Category name required");
            OnGet();
            return Page();
        }

        try
        {
            var cat = new Category { Name = NewCategory.Trim() };
            _db.Category.Add(cat);
            _db.SaveChanges();
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            OnGet();
            return Page();
        }
    }

    public int GetCount(string category)
    {
        try
        {
            // use lambda expression and join of tables
            var cnt = (from p in _db.Product
                       join c in _db.Category on p.CategoryId equals c.Id
                       where c.Name == category
                       select p).Count();
            return cnt;
        }
        catch
        {
            return 0;
        }
    }
}
