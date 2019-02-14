using ClothingStore.Contracts;
using ClothingStore.DAL;
using System.Collections.Generic;
using System.Linq;

namespace ClothingStore.Services
{
    public class CustomerService: ICustomerService
    {
        /// <summary>
        /// Show items which publish for customer for buy
        /// </summary>
        /// <returns></returns>
        public List<BaseItem> GetPublishItems()
        {
            return DataBaseHandle.stockItems.Where(item => item.Public).ToList();
        }

        public void RemoveItemsFromStockList(BaseItem removeItem)
        {
            var removedItem = DataBaseHandle.stockItems.Find(x => x.Id == removeItem.Id);

            if (removedItem == null)
            {
                throw new System.Exception("Item does not exist");
                
            }

            DataBaseHandle.RemoveItemsFromStockList(removedItem);
            
        }
    }
}
