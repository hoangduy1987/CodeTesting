using ClothingStore.Contracts;
using ClothingStore.DAL;
using System;
using System.Collections.Generic;

namespace ClothingStore.Services
{
    public class VendorService : IVendorService
    {
        /// <summary>
        /// Get Available items current on market for vender
        /// </summary>
        /// <returns></returns>
        public List<BaseItem> GetAvailableItems()
        {
            return DataBaseHandle.GetAvailableItemOnMarket();
        }

        /// <summary>
        /// Get current stock items
        /// </summary>
        /// <returns></returns>
        public List<BaseItem> GetStockItems()
        {
            return DataBaseHandle.GetStockItems();
        }

        /// <summary>
        /// Update Stock Items Information
        /// </summary>
        /// <param name="baseItem"></param>
        /// <returns></returns>
        public bool UpdateStockItems(BaseItem baseItem)
        {
            var currentBaseItem = DataBaseHandle.stockItems.Find(x => x.Id == baseItem.Id);

            if (currentBaseItem == null)
                throw new Exception("Item not exists");

            currentBaseItem.Size = baseItem.Size;
            currentBaseItem.Description = baseItem.Description;
            currentBaseItem.Color = baseItem.Color;
            currentBaseItem.ImportPrice = baseItem.ImportPrice;
            currentBaseItem.RetailPrice = baseItem.RetailPrice;

            return true;
        }

        /// <summary>
        /// Add new item to stock
        /// </summary>
        /// <param name="baseItem"></param>
        /// <returns></returns>
        public bool AddItemToStock(BaseItem baseItem)
        {
            try
            {
                DataBaseHandle.stockItems.Add(baseItem);
            }
            catch (Exception ex)
            {
                //ToDo: Log error system Elmah, Nlog
                return false;
            }

            return true;
            
        }
    }
}
