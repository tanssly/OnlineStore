using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore;

public class PurchaseHistoryRepository(DatabaseContext databaseContext) : IPurchaseHistoryRepository
{
    private DatabaseContext databaseContext { get; set; } = databaseContext;

    public void Create(PurchaseHistory purchase)
    {
        databaseContext.Purchases.Add(purchase);
    }

    public List<PurchaseHistory> ReadAll()
    {
        return databaseContext.Purchases.Count == 0 ? new List<PurchaseHistory>() : DbContext.Purchases;
    }

    public PurchaseHistory ReadByIndex(int purchaseIndex)
    {
        return databaseContext.Purchases.FirstOrDefault(p => p.PurchaseIndex == purchaseIndex);
    }

    public void Update(PurchaseHistory updatedPurchase)
    {
        var purchase = databaseContext.Purchases.FirstOrDefault(p => p.PurchaseIndex == updatedPurchase.PurchaseIndex);
        if (purchase != null)
        {
            purchase.ProductName = updatedPurchase.ProductName;
            purchase.Quantity = updatedPurchase.Quantity;
            purchase.TotalPrice = updatedPurchase.TotalPrice;
            purchase.DateOfPurchase = updatedPurchase.DateOfPurchase;
        }
        else
        {
            throw new ArgumentException("Purchase not found.");
        }
    }

    public void Delete(int purchaseIndex)
    {
        var purchase = databaseContext.Purchases.FirstOrDefault(p => p.PurchaseIndex == purchaseIndex);
        if (purchase != null)
        {
            databaseContext.Purchases.Remove(purchase);
        }
        else
        {
            throw new ArgumentException("Purchase not found.");
        }
    }
}
