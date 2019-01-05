using System.Web.Mvc;
using System.Web.Routing;

namespace CafeOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang/{id}",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new string[] { "CafeOnline.Controllers" }
            );
            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "CafeOnline.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "CafeOnline.Controllers" }
            );
            routes.MapRoute(
                name: "phantrangsp",
                url: "trang",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "CafeOnline.Controllers" }
            );
            routes.MapRoute(
                name: "Cart",
                url: "gio-hang",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "CafeOnline.Controllers" }
            );
            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new string[] { "CafeOnline.Controllers" }
            );
            routes.MapRoute(
                name: "Payment success",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new string[] { "CafeOnline.Controllers" }
            );
        }
    }
}