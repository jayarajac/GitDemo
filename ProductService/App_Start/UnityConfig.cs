using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ProductCommon;
using ProductProvider;
using ProductRepository;
using System.Web.Http;
using Unity.WebApi;

namespace ProductService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.LoadConfiguration("myContainer");
            //container.RegisterType<IProductProvider, Business>();
            //container.RegisterType<IProductRepository, Data>();

            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}