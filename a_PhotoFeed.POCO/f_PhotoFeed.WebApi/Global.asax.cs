using System;
using System.Web.Http;
using e_PhotoFeed.Services;
using f_PhotoFeed.WebApi.App_Start;
using f_PhotoFeed.WebApi.Filters;

namespace f_PhotoFeed.WebApi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Register WebApi routes
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Register custom filters
            GlobalConfiguration.Configuration.Filters.Add(new PhotoFeedExceptionAttribute());

            // Register AutoMapper profiles
            ServicesBootstrap.ConfigureAutoMapper();

            // Configure Unity
            GlobalConfiguration.Configure(UnityConfig.RegisterComponents);
        }
        
    }
}