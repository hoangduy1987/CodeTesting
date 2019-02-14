using ClothingStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Contracts
{
    public interface ICustomerService
    {
        List<BaseItem> GetPublishItems();
        void RemoveItemsFromStockList(BaseItem baseItem);
    }
}
