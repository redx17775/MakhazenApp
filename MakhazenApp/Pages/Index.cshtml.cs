using Microsoft.AspNetCore.Mvc.RazorPages;
using MakhazenApp.Data;
using Microsoft.EntityFrameworkCore;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IndexModel(ApplicationDbContext db) { _db = db; }
    public int ProductCount { get; set; }
    public int CategoryCount { get; set; }
    public IEnumerable<object> ProductGroupByCategory { get; set; } = Enumerable.Empty<object>();

    public void OnGet()
    {
        try
        {
            // LINQ simple count
            ProductCount = _db.Product.Count();
        }
        catch { ProductCount = 0; }

        try
        {
            // Count categories from Category table
            CategoryCount = _db.Category.Count();
        }
        catch { CategoryCount = 0; }

        try
        {
            // group products by category name (group by + join)
            var q = from p in _db.Product
                    join c in _db.Category on p.CategoryId equals c.Id
                    group p by c.Name into g
                    select new { Category = g.Key, Count = g.Count(), AvgPrice = g.Average(x => x.Price) };

            ProductGroupByCategory = q.AsNoTracking().ToList();
        }
        catch
        {
            ProductGroupByCategory = Enumerable.Empty<object>();
        }
    }
}
