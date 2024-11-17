using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanDT.Models;
using Web_BanDT.Models.csdl;
using Web_BanDT.Models.connect;
using System.Reflection;

namespace Web_BanDT.Areas.admin.Controllers
{
    public class productCategoryController : Controller
    {
        // GET: admin/productCategory
        CNproductCategory obj = new CNproductCategory();
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
       
                return Redirect("/taiKhoan/DangNhap");

            }
            else
            {
                List<LoaiSanPham> newlist = obj.listLoaiSP();
                return View(newlist);

            }
         
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(LoaiSanPham model)
        {
            if (ModelState.IsValid)
            {
                model.CreatyDate = DateTime.Now;
                model.biDanh = Web_BanDT.Models.chung.filter.FilterChar(model.tieuDe);
                obj.insertLoaiSP(model.tieuDe, model.SeoTieuDe, model.SeoMoTa, model.SeoTuKhoa, model.CreatyDate, model.biDanh);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            LoaiSanPham LoaiSanPhams = obj.showLoaiSp(id);
            return View(LoaiSanPhams);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiSanPham model, int id)
        {
            if (ModelState.IsValid)
            {
                model.biDanh = Web_BanDT.Models.chung.filter.FilterChar(model.tieuDe);
                obj.editLoaiSP(id, model.MaSanPham,model.tieuDe, model.moTa,model.SeoMoTa, model.SeoTuKhoa, model.SeoTieuDe, model.biDanh);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult delete(int id)
        {
            LoaiSanPham LoaiSanPhams = obj.showLoaiSp(id);
            return View(LoaiSanPhams);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult delete(LoaiSanPham model)
        {
            obj.deleteLoaiSP(model.id);
            return RedirectToAction("Index");
        }
    }
}