using OnlineStore.Models;

namespace OnlineStore;

public interface IPurchaseHistoryService
{
    void Create(PurchaseHistory purchase);
    List<PurchaseHistory> ReadAll();
    PurchaseHistory ReadByIndex(int purchaseIndex);
    void Delete(int purchaseIndex);
    void Update(PurchaseHistory updatedPurchase);

    void RecordPurchase(Product product, int quantity, CustomerAccount customer);
}
