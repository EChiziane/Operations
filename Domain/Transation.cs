namespace Domain;

public class Transaction : BaseEntity
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public TransactionType Type { get; set; }
}