using System.ComponentModel.DataAnnotations.Schema;

namespace Makhazen.Models;
[Table("Category")]
public class Category
{
    [Column("CategoryID")]
    public int Id { get; set; }

    [Column("CategoryName")]
    public string Name { get; set; } = string.Empty;
}
