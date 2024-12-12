using OnlineStore.Models;

namespace OnlineStore;

public interface IPurchaseHistoryRepository
{
    void Create(PurchaseHistory purchase);
    List<PurchaseHistory> ReadAll();
    PurchaseHistory ReadByIndex(int purchaseIndex);
    void Delete(int purchaseIndex);
    void Update(PurchaseHistory updatedPurchase);
}
