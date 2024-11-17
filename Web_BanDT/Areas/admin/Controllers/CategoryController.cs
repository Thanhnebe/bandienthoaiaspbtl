using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanDT.Models;
using Web_BanDT.Models.csdl;
using Web_BanDT.Models.connect;

namespace Web_BanDT.Areas.admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: admin/Category
      
        CNcategory obj = new CNcategory();
        // GET: Admin/Category
        NHANVIEN nvSS = (NHANVIEN)System.Web.HttpContext.Current.Session["username"];

        public ActionResult Index()
        {
      

            if (Session["username"] == null)
            {
                return Redirect("/taiKhoan/DangNhap");

            }
            else
            {
                List<Category> categories = obj.categories();
                return View(categories);

            }  
       
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {

                model.CreatyDate = DateTime.Now;
                model.biDanh = Web_BanDT.Models.chung.filter.FilterChar(model.TieuDe);
                model.idNhanVien = nvSS.ID;
                obj.themCategory(model, model.CreatyDate, model.biDanh, model.idNhanVien);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            Category category = obj.showcateGory(id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.biDanh = Web_BanDT.Models.chung.filter.FilterChar(model.TieuDe);
                model.idNhanVien = nvSS.ID;
                model.ModifiedBy = nvSS.tenNhanVien;
                obj.editCateGory(model, model.ModifiedDate, model.biDanh, model.idNhanVien, model.ModifiedBy);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult delete(int id)
        {
            Category category = obj.showcateGory(id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult delete(Category model)
        {
            obj.deleteCategory(model.Id);
            return RedirectToAction("Index");
        }


    }
}