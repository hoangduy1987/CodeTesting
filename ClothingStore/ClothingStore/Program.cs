using ClothingStore.Contracts;
using ClothingStore.DAL;
using ClothingStore.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace ClothingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Init Required Component & Service
            var container = Bootstraper.Initialize();
            var uiHandle = new UIHandle();
            DataBaseHandle.Init();
            var vendorService = container.Resolve<IVendorService>();
            var customerService = container.Resolve<ICustomerService>();

            do
            {
                uiHandle.RenderIndexPage();

                //Select Actions
                int selectedUserType = Convert.ToInt16(Console.ReadLine());

                switch (selectedUserType)
                {
                    case 1: //Vendor
                        #region Vendor Functions

                        do
                        {
                            // Show vendor actions
                            uiHandle.RenderVendorAction();

                            //Select Actions
                            int selectedAction = Convert.ToInt16(Console.ReadLine());

                            try
                            {
                                switch (selectedAction)
                                {
                                    case 1:
                                        GetMarketItemsAction(vendorService, uiHandle);
                                        break;
                                    case 2:
                                        UpdateStockItemsInformation(vendorService, uiHandle);
                                        break;
                                    case 3:
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        } while (true);
                        #endregion
                        continue;
                    case 2: //Customer
                        #region Customer Functions

                        do
                        {
                            uiHandle.RenderCustomerAction();

                            //Select Actions
                            int selectedAction = Convert.ToInt16(Console.ReadLine());

                            if (selectedAction == 2) break;

                            var publishItems = customerService.GetPublishItems();

                            uiHandle.RenderPublishItem(publishItems);

                            RemoveStockItem(customerService, uiHandle, publishItems);

                        } while (true);
                        break;
                    #endregion
                    default:
                        Console.WriteLine("User Type not exists");
                        break;
                }

            } while (true);
            

        }

        /// <summary>
        /// Get Market Items list Action Handle
        /// </summary>
        /// <param name="vendorService"></param>
        /// <param name="uiHandle"></param>
        private static void GetMarketItemsAction(IVendorService vendorService, UIHandle uiHandle)
        {
            //Get current item on market for vendor
            var availableItems = vendorService.GetAvailableItems();

            // Show current items on market 
            uiHandle.RenderListItemForVendor(availableItems);

            do
            {
                //Select Item
                string selectedItem = Console.ReadLine();

                if (selectedItem.ToLower() == "back")
                    break;

                char selectedBaseItem = Convert.ToChar(selectedItem);

                var index = uiHandle.alphabet.IndexOf(selectedBaseItem);
                BaseItem selectedMarketItem = null;

                try
                {
                    selectedMarketItem = availableItems[index];

                    //Add item to stock list
                    vendorService.AddItemToStock(selectedMarketItem);

                    //Remove item from market list
                    DataBaseHandle.RemoveItemsFromMarketList(selectedMarketItem);

                    Console.WriteLine("Item added successfull, add another or press Back to action list !");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Item selected not exists please try again");
                }

            } while (true);
        }

        /// <summary>
        /// Update Stock Item Information Handle
        /// </summary>
        /// <param name="vendorService"></param>
        /// <param name="uiHandle"></param>
        private static void UpdateStockItemsInformation(IVendorService vendorService, UIHandle uiHandle)
        {
            //Get current item on market for vendor
            var stockItems = vendorService.GetStockItems();

            if(!stockItems.Any())
            {
                Console.WriteLine("No stock items available");
            }
            else
            {
                // Show current items on stock 
                uiHandle.RenderStockItems(stockItems);

                do
                {
                    //Select Item
                    char selectedItem = Convert.ToChar(Console.ReadLine());

                    var index = uiHandle.alphabet.IndexOf(selectedItem);
                    BaseItem selectedStockItem = null;

                    try
                    {
                        selectedStockItem = stockItems[index];

                        uiHandle.RenderStockItem(selectedStockItem);


                        Console.WriteLine("Update retail price:");
                        var newRetailPrice = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Publish to customer for buying:");
                        var publish = Console.ReadLine();
                        var isPublish = false;

                        switch (publish.ToLower())
                        {
                            case "yes":
                            case "y":
                                isPublish = true;
                                break;
                        }

                        vendorService.UpdateStockItems(new BaseItem
                        {
                            Id = selectedStockItem.Id,
                            Color = selectedStockItem.Color,
                            Size = selectedStockItem.Size,
                            ImportPrice = selectedStockItem.ImportPrice,
                            RetailPrice = newRetailPrice,
                            Description = selectedStockItem.Description,
                            Public = isPublish
                        });

                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Item selected not exists please try");
                    }

                } while (true);
            }
            
        }

        private static void RemoveStockItem(ICustomerService customerService, UIHandle uiHandle, List<BaseItem> publishItem)
        {
            do
            {
                //Select Item
                char selectedItem = Convert.ToChar(Console.ReadLine());

                var index = uiHandle.alphabet.IndexOf(selectedItem);
                BaseItem selectedStockItem = null;

                try
                {
                    selectedStockItem = publishItem[index];

                    customerService.RemoveItemsFromStockList(selectedStockItem);

                    Console.WriteLine("Item buy successful");
                    

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Item selected not exists please try");
                }

            } while (true);
        }
    }
}
