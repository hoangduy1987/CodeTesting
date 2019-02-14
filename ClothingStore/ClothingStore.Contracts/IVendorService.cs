
using ClothingStore.DAL;
using System.Collections.Generic;

namespace ClothingStore.Contracts
{
    public interface IVendorService
    {
        List<BaseItem> GetAvailableItems();
        List<BaseItem> GetStockItems();
        bool AddItemToStock(BaseItem baseItem);
        bool UpdateStockItems(BaseItem baseItem);
    }
}
