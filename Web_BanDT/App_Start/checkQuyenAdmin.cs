using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Web_BanDT.Models.EF;

namespace Web_BanDT.App_Start
{
    public class checkQuyenAdmin : AuthorizeAttribute
    {
        public int idChucNang { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // check sesision: da dang nhap => da cho thuc hien filter
            // nguoc lai thi khong cho thuc hien tro lai trang dang nhap
            NHANVIEN nvSS = (NHANVIEN)HttpContext.Current.Session["username"];
            if (nvSS != null)
            {
                WEBSITE_BANHANGEntities1 db = new  WEBSITE_BANHANGEntities1();
                var count = db.NhanVien_ChucNang.Count(m => m.IDnhanVien == nvSS.ID && m.IDnchucNang == idChucNang);
                if (count != 0)
                {
                    return;
                }
                else
                {
                    var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                          new
                          {
                              Controller = "BaoLoi",
                              action = "KhongCoQuyen",
                              area = "admin",
                              returnUrl = returnUrl.ToString()
                          }));
                }
                return;
            }
            else
            {
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                      new
                      {
                          Controller = "Home",
                          action = "DangNhap",
                          area = "admin",
                          returnUrl = returnUrl.ToString()
                      }));
            }



        }
    }
}