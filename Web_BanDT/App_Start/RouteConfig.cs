using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web_BanDT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "LienHe",
               url: "Lien-He",
               defaults: new { controller = "LienHe", action = "Index", biDanh = UrlParameter.Optional },
               namespaces: new[] { "Web_BanDT.Controllers" }

           );
            routes.MapRoute(
            name: "ThanhToan",
            url: "thanh-toan",
            defaults: new { controller = "ShoppingCart", action = "thanhToan", biDanh = UrlParameter.Optional },
            namespaces: new[] { "Web_BanDT.Controllers" }

        );
            routes.MapRoute(
            name: "ShoppingCart",
            url: "gio-hang",
            defaults: new { controller = "ShoppingCart", action = "Index", biDanh = UrlParameter.Optional },
            namespaces: new[] { "Web_BanDT.Controllers" }

        );
            routes.MapRoute(
            name: "HuyDonHang",
            url: "huyDonHang/{id}",
            defaults: new { controller = "ShoppingCart", action = "HuyDonHang", id = UrlParameter.Optional },
            namespaces: new[] { "Web_BanDT.Controllers" }
        );

            routes.MapRoute(
              name: "LoaiSanPhamS",
              url: "danh-muc-san-pham/{biDanh}-{id}",
              defaults: new { controller = "Product", action = "productCategory", biDanh = UrlParameter.Optional },
              namespaces: new[] { "Web_BanDT.Controllers" }

          );
            routes.MapRoute(
                name: "DetailSP",
                url: "chi-Tiet/{biDanh}-p{id}",
                defaults: new { controller = "Product", action = "DetailSP", biDanh = UrlParameter.Optional },
                namespaces: new[] { "Web_BanDT.Controllers" }

            );

            routes.MapRoute(
                name: "LoaiSanPham",
                url: "san-pham",
                defaults: new { controller = "Product", action = "Index", biDanh = UrlParameter.Optional },
                namespaces: new[] { "Web_BanDT.Controllers" }

            );
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "Web_BanDT.Controllers" }

           );
        }
    }
}
