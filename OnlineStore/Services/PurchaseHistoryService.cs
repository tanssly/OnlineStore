using OnlineStore.Models;

namespace OnlineStore;

public class PurchaseHistoryService(PurchaseHistoryRepository repository) : IPurchaseHistoryService
{
    private PurchaseHistoryRepository Repository { get; set; } = repository;

    public void Create(PurchaseHistory purchase)
    {
        Repository.Create(purchase);
    }

    public List<PurchaseHistory> ReadAll()
    {
        return Repository.ReadAll();
    }

    public PurchaseHistory ReadByIndex(int purchaseIndex)
    {
        return Repository.ReadByIndex(purchaseIndex);
    }

    public void Delete(int purchaseIndex)
    {
        Repository.Delete(purchaseIndex);
    }

    public void Update(PurchaseHistory updatedPurchase)
    {
        Repository.Update(updatedPurchase);
    }

    public void RecordPurchase(Product product, int quantity, CustomerAccount customer)
    {
        if (product.Stock < quantity)
        {
            throw new InvalidOperationException("Not enough stock available.");
        }

        // Зменшення кількості товару на складі
        product.Stock -= quantity;

        // Розрахунок загальної ціни
        var totalPrice = product.Price * quantity;

        // Створення запису в історії покупок
        var purchaseHistory = new PurchaseHistory
        {
            CustomerName = customer.UserName,
            ProductName = product.Name,
            Quantity = quantity,
            TotalPrice = totalPrice,
            DateOfPurchase = DateTime.Now,
            PurchaseIndex = GeneratePurchaseIndex(),
            CustomerId = customer.Id
        };

        // Збереження в репозиторій
        Create(purchaseHistory);
    }

    private int GeneratePurchaseIndex()
    {
        var purchases = ReadAll();
        return purchases.Count > 0 ? purchases.Max(p => p.PurchaseIndex) + 1 : 1;
    }
}
