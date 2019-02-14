using ClothingStore.Common;
using ClothingStore.DAL.Entities;
using System.Collections.Generic;

namespace ClothingStore.DAL
{
    /// <summary>
    /// Init Data for Application
    /// </summary>
    public static class DataBaseHandle
    {
        public static List<BaseItem> stockItems;
        public static List<BaseItem> marketItems;

        /// <summary>
        /// Init Stock Items list and available Items
        /// </summary>
        public static void Init()
        {
            stockItems = new List<BaseItem> {
                new ShirtItem
                {
                    Id = 1,
                    Description = "Lacoste Dress Shirt",
                    Color = ColorEnum.Blue,
                    ImportPrice = 12,
                    Size = SizeEnum.M,
                    Public = true,
                    RetailPrice = 23
                },
                new ShirtItem
                {
                    Id = 2,
                    Description = "LV Dress Shirt",
                    Color = ColorEnum.Blue,
                    ImportPrice = 12,
                    Size = SizeEnum.S,
                    Public = true,
                    RetailPrice = 45
                }
            };

            marketItems = new List<BaseItem>
            {
                new ShirtItem
                {
                    Id = 1,
                    Description = "Lacoste Dress Shirt",
                    Color = ColorEnum.Blue,
                    ImportPrice = 12,
                    Size = SizeEnum.M
                },
                new ShirtItem
                {
                    Id = 2,
                    Description = "LV Dress Shirt",
                    Color = ColorEnum.Blue,
                    ImportPrice = 12,
                    Size = SizeEnum.S
                },
                new TShirtItem
                {
                    Id = 3,
                    Description = "Abercrombie Tshirt",
                    Color = ColorEnum.Red,
                    ImportPrice = 12,
                    Size = SizeEnum.S
                },
                new TShirtItem
                {
                    Id = 4,
                    Description = "Levis Tshirt",
                    Color = ColorEnum.Blue,
                    ImportPrice = 12,
                    Size = SizeEnum.L
                },
            };
        }

        /// <summary>
        /// Return Available Item on Market
        /// </summary>
        /// <returns></returns>
        public static List<BaseItem> GetAvailableItemOnMarket()
        {
            return marketItems;
        }

        /// <summary>
        /// Return Available Item on Market
        /// </summary>
        /// <returns></returns>
        public static List<BaseItem> GetStockItems()
        {
            return stockItems;
        }

        /// <summary>
        /// Remove current item from market list
        /// </summary>
        /// <param name="baseItem"></param>
        public static void RemoveItemsFromMarketList(BaseItem baseItem)
        {
            marketItems.Remove(baseItem);
        }

        /// <summary>
        /// Remove current item from stock list
        /// </summary>
        /// <param name="baseItem"></param>
        public static void RemoveItemsFromStockList(BaseItem baseItem)
        {
            stockItems.Remove(baseItem);
        }

    }
}
