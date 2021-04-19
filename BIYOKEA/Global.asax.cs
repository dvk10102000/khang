using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BIYOKEA.Models;

namespace BIYOKEA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["pageView"] = 0;
            Application["viewOnline"] = 0;
        }
        protected void Session_Start()
        {
            List<HoaDon> cart = new List<HoaDon>();
            Session["cart"] = cart;
            Application.Lock();
            Application["pageView"] = (int)Application["pageView"] + 1;
            Application["viewOnline"] = (int)Application["viewOnline"] + 1;
            Application.UnLock();

        }
        protected void Session_End()
        {
            Application.Lock();
            Application["viewOnline"] = (int)Application["viewOnline"] - 1;
            Application.UnLock();
        }
    }
}
