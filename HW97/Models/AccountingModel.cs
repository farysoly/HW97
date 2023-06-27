namespace HW97.Models;

public class AccountingModel
{
    public int UserId { get; set; }
    public string AccountingName { get; set; }
    public double Debit { get; set; }
    public double Credit { get; set; }
    public double TransactionDate { get; set; }
    public string Description { get; set; }
}
