using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Web_BanDT.Models;
using Web_BanDT.Models.csdl;
using Web_BanDT.Models.connect;
using System.Web;

namespace Web_BanDT.Areas.admin.Controllers
{
    public class TinTucController : Controller
    {
        // GET: admin/TinTuc
        CNNews obj = new CNNews();
        public ActionResult Index(string Searchtext, int? page)
        {
            if (Session["username"] == null)
            {
                return Redirect("/taiKhoan/DangNhap");

            }
            else
            {
                var pageSize = 10;
                if (page == null)
                {
                    page = 1;
                }
                //OrderByDescending(x => x.id); tạo sau ra trước
                IEnumerable<ThongBaoMoi> items = obj.listTB().OrderByDescending(x => x.id);

                if (!string.IsNullOrEmpty(Searchtext))
                {
                    items = obj.search(Searchtext);
                }
                //hasValue: dùng để kiểm tra xem page mới truyền vào có giá trị không
                // nếu có giá trị thì nó sử dụng, ngược lại gắn bằng 1
                var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                items = items.ToPagedList(pageIndex, pageSize);
                ViewBag.PageSize = pageSize;
                ViewBag.Page = page;
                return View(items);

            }

        }
        public ActionResult Add()
        {
            ViewBag.categoryLst = new SelectList(obj.listCateGory(), "ID", "TieuDe");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ThongBaoMoi model)
        {
          

            if (ModelState.IsValid)
            {
                NHANVIEN nvSS = (NHANVIEN)System.Web.HttpContext.Current.Session["username"];
                ViewBag.categoryLst = new SelectList(obj.listCateGory(), "ID", "TieuDe");
                model.CreatyDate = DateTime.Now;
                model.biDanh = Web_BanDT.Models.chung.filter.FilterChar(model.tieuDe);
                model.idNhanVien = nvSS.ID;
                obj.insertNews(model, model.CreatyDate, model.biDanh, model.idNhanVien);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ThongBaoMoi ThongBaoMois = obj.showNews(id);
            return View(ThongBaoMois);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ThongBaoMoi model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.biDanh = Web_BanDT.Models.chung.filter.FilterChar(model.tieuDe);
                obj.editNews(model.id, model.tieuDe, model.moTa, model.image, model.SeoTieuDe, model.SeoMoTa, model.SeoTuKhoa, model.ModifiedDate, model.biDanh);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult delete(int id)
        {
            ThongBaoMoi ThongBaoMois = obj.showNews(id);
            return View(ThongBaoMois);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult delete(ThongBaoMoi model)
        {
            obj.deleteNews(model.id);
            return RedirectToAction("Index");
        }

    }
}