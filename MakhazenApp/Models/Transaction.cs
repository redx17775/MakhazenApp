using System.ComponentModel.DataAnnotations;

namespace Makhazen.Models;
public class Transaction
{
    public int TransactionID { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public string TransactionType { get; set; } = "Purchase";
    public int Quantity { get; set; }
    public int ProductID { get; set; }
}
