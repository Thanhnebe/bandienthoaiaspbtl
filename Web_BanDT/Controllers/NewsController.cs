using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanDT.Models.EF;

namespace Web_BanDT.Controllers
{
    public class NewsController : Controller
    {
        private WEBSITE_BANHANGEntities1 db = new WEBSITE_BANHANGEntities1();

        // GET: News
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Partial_news_home()
        {
            var items = db.tb_ThongBaoMoi.Take(3).ToList();
            return PartialView(items);
        }
    }
}