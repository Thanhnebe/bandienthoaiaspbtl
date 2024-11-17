using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_BanDT.Areas.admin.Controllers
{
    public class BaoLoiController : Controller
    {
        // GET: admin/BaoLoi
        public ActionResult KhongCoQuyen()
        {
            return View();
        }
        public ActionResult BaoLoi() {
            return View();

        }
    }
}