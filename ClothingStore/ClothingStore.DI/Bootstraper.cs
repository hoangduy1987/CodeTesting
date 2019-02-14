using ClothingStore.Contracts;
using ClothingStore.Services;
using Unity;

namespace ClothingStore.DI
{
    public static class Bootstraper
    {
        /// <summary>
        /// Initialize Unity Container
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer Initialize()
        {
            var container = new UnityContainer();
            RegisterType(container);
            return container;
        }

        /// <summary>
        /// Register container type
        /// </summary>
        /// <param name="container">Unity Container</param>
        private static void RegisterType(IUnityContainer container)
        {
            //Services
            container.RegisterType<ICommonService, CommonService>()
                     .RegisterType<IVendorService, VendorService>()
                     .RegisterType<ICustomerService, CustomerService>();
        }
    }
}
