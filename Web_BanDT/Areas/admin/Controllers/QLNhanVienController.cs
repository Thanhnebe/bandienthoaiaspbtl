using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanDT.Models.connect;
using Web_BanDT.Models.csdl;

namespace Web_BanDT.Areas.admin.Controllers
{
    public class QLNhanVienController : Controller
    {
        // GET: admin/QLNhanVien
        CNTaiKhoan db = new CNTaiKhoan();
      

        public ActionResult Index()
        {

            if (Session["username"] == null)
            {
                return Redirect("/taiKhoan/DangNhap");

            }
            else
            {
                List<NHANVIEN> items = db.ListNV();
                return View(items);

            }
        }
        
        public ActionResult dangKyNhanVien()
        {
            var phanquyen = db.listPhanQuyen(); 
            SelectList PQSelectList = new SelectList(phanquyen, "ID", "tenQuyen");
            ViewBag.Phanquyen = PQSelectList;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult dangKyNhanVien(NHANVIEN nv)
        {
            ViewBag.PhanQuyen = new SelectList(db.listPhanQuyen(), "ID", "tenQuyen");
            if (ModelState.IsValid)
            {
                db.themNV(nv);
                return RedirectToAction("Index");
            }
            return View(nv);

        }
        public ActionResult capNhatNhanVien(int id)
        {
            ViewBag.PhanQuyen = new SelectList(db.listPhanQuyen(), "ID", "tenQuyen");
            var item = db.showNhanVien(id);

            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult capNhatNhanVien(NHANVIEN nv)
        {
            ViewBag.PhanQuyen = new SelectList(db.listPhanQuyen(), "ID", "tenQuyen");

            if (ModelState.IsValid)
            {
                db.editNhanVien(nv);
                return RedirectToAction("Index");
            }
            return View(nv);

        }

        public ActionResult XoaNhanVien(int id)
        {
            var item = db.showNhanVien(id);

            if (item != null)
            {
                db.deleteNhanVien(id);
            }
            return RedirectToAction("Index");
        }

    }
}