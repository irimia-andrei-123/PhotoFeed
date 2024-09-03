
using System.Web.Http;
using CommonServiceLocator;
using e_PhotoFeed.Services;
using Unity.ServiceLocation;
using Unity.WebApi;

namespace f_PhotoFeed.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = ServicesBootstrap.ConfigureUnityContainer();

            var locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}