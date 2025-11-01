using System.ComponentModel.DataAnnotations;
namespace Makhazen.Models;
public class Order
{
    public int Id { get; set; }
    [Required] public string ProductCode { get; set; } = string.Empty;
    [Required] public string CustomerName { get; set; } = string.Empty;
    [Range(1, 1000)] public int Quantity { get; set; }
}
