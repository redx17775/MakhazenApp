using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Makhazen.Models;
using MakhazenApp.Data;
using Microsoft.EntityFrameworkCore;

public class EditProductModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public EditProductModel(ApplicationDbContext db) { _db = db; }

    [BindProperty]
    public Product Product { get; set; } = new();

    public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();
    public string? ErrorMessage { get; set; }

    public void OnGet(int id)
    {
        LoadCategories();
        try
        {
            var p = _db.Product.Find(id);
            if (p != null)
            {
                Product = p;
            }
            else
            {
                ErrorMessage = "Product not found";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            LoadCategories();
            return Page();
        }

        try
        {
            var existing = _db.Product.Find(Product.Id);
            if (existing == null)
            {
                ModelState.AddModelError(string.Empty, "Product not found");
                LoadCategories();
                return Page();
            }

            existing.Name = Product.Name;
            existing.Code = Product.Code;
            existing.CategoryId = Product.CategoryId == 0 ? existing.CategoryId : Product.CategoryId;
            existing.Stock = Product.Stock;
            existing.Price = Product.Price;
            existing.PhotoUrl = Product.PhotoUrl;
            existing.Status = string.IsNullOrWhiteSpace(Product.Status) ? existing.Status : Product.Status;

            _db.Product.Update(existing);
            _db.SaveChanges();
            return RedirectToPage("/Products");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            LoadCategories();
            return Page();
        }
    }

    private void LoadCategories()
    {
        try
        {
            Categories = _db.Category.AsNoTracking().OrderBy(c => c.Name).ToList();
        }
        catch
        {
            Categories = Enumerable.Empty<Category>();
        }
    }
}
