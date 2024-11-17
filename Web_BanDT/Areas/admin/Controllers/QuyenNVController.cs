using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Web_BanDT.Models.EF;

namespace Web_BanDT.Areas.admin.Controllers
{
    public class QuyenNVController : Controller
    {
        // GET: admin/QuyenNV
        private WEBSITE_BANHANGEntities1 db = new WEBSITE_BANHANGEntities1();
        public ActionResult Index()
        {
         
            if (Session["username"] == null)
            {
                return Redirect("/taiKhoan/DangNhap");

            }
            else
            {
                var item = db.PHANQUYENs.ToList();
                return View(item);

            }
        }
        public ActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PHANQUYEN quyen)
        {
            if (ModelState.IsValid)
            {
                db.PHANQUYENs.Add(quyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quyen);
        }
  
        public ActionResult Delete(int id)
        {
            var item = db.PHANQUYENs.Find(id);

            if (item != null)
            {
                db.PHANQUYENs.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}