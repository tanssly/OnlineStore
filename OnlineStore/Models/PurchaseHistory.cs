namespace OnlineStore;

public class PurchaseHistory
{
    public int PurchaseIndex { get; set; }
    public string CustomerName { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime DateOfPurchase { get; set; }
    public Guid CustomerId { get; set; }
}
