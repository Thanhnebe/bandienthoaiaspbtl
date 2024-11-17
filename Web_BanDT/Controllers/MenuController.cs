using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanDT.Models.connect;
using Web_BanDT.Models.csdl;
namespace Web_BanDT.Controllers
{
    public class MenuController : Controller
    {
        CNcategory objCate = new CNcategory();
        CNproductCategory objProductCate = new CNproductCategory();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuTop()
        {
            var item = objCate.categories().OrderBy(x => x.Id).ToList();
            return PartialView("MenuTop", item);
        }
        public ActionResult MenuProductCategory()
        {
            var item = objProductCate.listLoaiSP().ToList();
            return PartialView("MenuProductCategory", item);
        }
        public ActionResult MenuThanhTruot()
        {
            var item = objProductCate.listLoaiSP().ToList();
            return PartialView("MenuThanhTruot", item);
        }
        public ActionResult MenuLeft(int? id)
        {
            if (id != null)
            {
                ViewBag.CateID = id;
            }
            // chạy item trước
            var item = objProductCate.listLoaiSP().ToList();
            return PartialView("MenuLeft", item);
        }
    }
}