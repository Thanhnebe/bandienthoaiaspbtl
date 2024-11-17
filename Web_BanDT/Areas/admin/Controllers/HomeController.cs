using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web_BanDT.Models.EF;
using Web_BanDT.Models.connect;


namespace Web_BanDT.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        private WEBSITE_BANHANGEntities1 db = new WEBSITE_BANHANGEntities1();
        CNTaiKhoan obj = new CNTaiKhoan();
        // GET: admin/Home
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return Redirect("/Home/Index");

            }
            else
            {
                return View();

            }
            
        }
      
        public ActionResult DangXuat()
        {
            // xoa session
            Session.Remove("username");
            // xoa cokkie
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");


        }
    }
}