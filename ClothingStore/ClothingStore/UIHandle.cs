using ClothingStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClothingStore
{
    public class UIHandle
    {
        public List<char> alphabet;
        public UIHandle()
        {
            alphabet = Enumerable.Range('a', 26).Select(x => (char)x).ToList();
        }

        public void RenderIndexPage()
        {
            Console.WriteLine("Login as Customer or Vendor:");
            Console.WriteLine("1. Vendor");
            Console.WriteLine("2. Customer");
        }

        /// <summary>
        /// Render Customer Actions
        /// </summary>
        public void RenderCustomerAction()
        {
            Console.WriteLine("Which action do you want to take:");
            Console.WriteLine("1. Buy clothes");
            Console.WriteLine("2. Back");
            Console.WriteLine("Please pick actions you want:");
        }

        /// <summary>
        /// Render Customer Actions
        /// </summary>
        public void RenderPublishItem(List<BaseItem> baseItems)
        {
            Console.WriteLine("List Available Items:");
            var i = 0;
            foreach (var baseItem in baseItems)
            {
                Console.WriteLine($"{alphabet[i++]}. {baseItem.Description}");
            }
            Console.WriteLine("Please pick item you want to buy:");
        }

        /// <summary>
        /// Render Vendor Action
        /// </summary>
        public void RenderVendorAction()
        {
            Console.WriteLine("Which action do you want to take:");
            Console.WriteLine("1. Get items from market");
            Console.WriteLine("2. Update items information");
            Console.WriteLine("3. Back");
            Console.WriteLine("Please pick actions you want:");
        }
        
        /// <summary>
        /// Render List Item for Vendor at rate
        /// </summary>
        /// <param name="baseItems"></param>
        public void RenderListItemForVendor(List<BaseItem> baseItems)
        {
            Console.WriteLine("List Available Items:");
            
            var i = 0;
            foreach (var baseItem in baseItems)
            {
                Console.WriteLine($"{alphabet[i++]}. {baseItem.Description}");
            }
            Console.WriteLine("Please pick item you want to add to stock or input back to actions list:");
        }

        public void RenderStockItems(List<BaseItem> baseItems)
        {
            if (baseItems.Any())
            {
                Console.WriteLine("List Stock Items:");

                var i = 0;
                foreach (var baseItem in baseItems)
                {
                    Console.WriteLine($"{alphabet[i++]}. {baseItem.Description}");
                }
                Console.WriteLine("Please pick item you want to update:");
            }
            
        }

        public void RenderStockItem(BaseItem baseItem)
        {
            Console.WriteLine($"Description: {baseItem.Description}");
            Console.WriteLine($"Color: {baseItem.Color}");
            Console.WriteLine($"Size: {baseItem.Size}");
            Console.WriteLine($"Import Price: {baseItem.ImportPrice}");
            Console.WriteLine($"Retail Price: {baseItem.RetailPrice}");
            Console.WriteLine($"Publish?: {baseItem.Public}");
        }
    }
}
