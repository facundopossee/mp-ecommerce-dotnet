using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MercadoPago;

namespace mp_ecommerce
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SDK.SetAccessToken("APP_USR-6317427424180639-042414-47e969706991d3a442922b0702a0da44-469485398");
            SDK.SetIntegratorId("dev_24c65fb163bf11ea96500242ac130004");

        }
    }
}
