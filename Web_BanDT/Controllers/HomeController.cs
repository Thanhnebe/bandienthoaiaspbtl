using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanDT.Models.EF;

namespace Web_BanDT.Controllers
{
    public class HomeController : Controller
    {
        private WEBSITE_BANHANGEntities1 db = new WEBSITE_BANHANGEntities1();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Partial_DangKyNews()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Partial_DangKyNews(TB_datNhanThongBao dangKy)
        {
            if (ModelState.IsValid)
            {
                db.TB_datNhanThongBao.Add(new TB_datNhanThongBao { email = dangKy.email, CreateDate = DateTime.Now, name= dangKy.name });
                db.SaveChanges();
                return Json(new { Success = true });
            }
            return View("Partial_DangKyNews", dangKy);
        }
    }
}