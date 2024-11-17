using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using Web_BanDT.Models;
using Web_BanDT.Models.csdl;
using Web_BanDT.Models.connect;
using System.Web.Mvc;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Web_BanDT.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        CNProducts obj = new CNProducts();
        // GET: admin/Product
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
                IEnumerable<product_image> items = obj.listSP().OrderByDescending(x => x.id);

                //if (!string.IsNullOrEmpty(Searchtext))
                //{
                //    items = obj.search(Searchtext);
                //}
            
                var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                items = items.ToPagedList(pageIndex, pageSize);
                ViewBag.PageSize = pageSize;
                ViewBag.Page = page;

                return View(items);

            }

        }
        public ActionResult Add()
        {
            var productCategories = obj.listLoaiSP(); // Đây là danh sách các mục danh mục sản phẩm
            SelectList productCategorySelectList = new SelectList(productCategories, "id", "tieuDe");
            ViewBag.ProductCategories = productCategorySelectList;

            return View();
        }

        [HttpPost]
        public ActionResult Add(product model, ProductImage ImageSP, List<string> Images, List<int> rDefault)
        {
            ViewBag.ProductCategories = new SelectList(obj.listLoaiSP(), "id", "tieuDe");
            if (ModelState.IsValid)
            {
                model.CreatyDate = DateTime.Now;
                model.biDanh = Web_BanDT.Models.chung.filter.FilterChar(model.tieuDe);
                if (string.IsNullOrEmpty(model.SeoTieuDe))
                {
                    model.SeoTieuDe = model.tieuDe;
                }
                //insert bidanh
                obj.insertIntoProduct(model.tieuDe, model.productCategoryID, model.productCode, model.moTa, model.ChiTiet, model.price, model.priceSale, model.quantity, model.CreatyDate, model.CreatyBy, model.SeoMoTa, model.SeoTuKhoa, model.SeoTieuDe, model.isHome, model.isfearure, model.isHot, model.isSale, model.biDanh);
                int k = obj.getID();
                if (Images.Count > 0 && Images != null)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {

                        ImageSP.CreatyDate = DateTime.Now;
                        if (i + 1 == rDefault[0])
                        {
                            ImageSP.ProductId = k;
                            ImageSP.image = Images[i];
                            ImageSP.idDefault = true;
                            obj.InsertProductImages(ImageSP.ProductId, ImageSP.image, ImageSP.idDefault, ImageSP.CreatyDate, ImageSP.CreatyBy);
                        }
                        else
                        {
                            ImageSP.ProductId = k;
                            ImageSP.idDefault = false;
                            ImageSP.image = Images[i];
                            obj.InsertProductImages(ImageSP.ProductId, ImageSP.image, ImageSP.idDefault, ImageSP.CreatyDate, ImageSP.CreatyBy);
                        }
                    }
                }


                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var productCategories = obj.listLoaiSP(); // Đây là danh sách các mục danh mục sản phẩm
            SelectList productCategorySelectList = new SelectList(productCategories, "id", "tieuDe");
            ViewBag.ProductCategories = productCategorySelectList;
            var item = obj.Showproduct(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(product model)
        {
            ViewBag.ProductCategories = new SelectList(obj.listLoaiSP(), "id", "tieuDe");
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.biDanh = Web_BanDT.Models.chung.filter.FilterChar(model.tieuDe);
                if (string.IsNullOrEmpty(model.SeoTieuDe))
                {
                    model.SeoTieuDe = model.tieuDe;
                }

                obj.editProduct(model.id, model.tieuDe, model.productCategoryID, model.productCode, model.moTa, model.ChiTiet, model.price, model.priceSale, model.quantity, model.ModifiedDate, model.ModifiedBy, model.SeoMoTa, model.SeoTuKhoa, model.SeoTieuDe, model.isHome, model.isfearure, model.isHot, model.isSale, model.biDanh);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult delete(int id)
        {
            var productCategories = obj.listLoaiSP(); // Đây là danh sách các mục danh mục sản phẩm
            SelectList productCategorySelectList = new SelectList(productCategories, "id", "tieuDe");
            ViewBag.ProductCategories = productCategorySelectList;
            product products = obj.Showproduct(id);
            return View(products);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult delete(product model)
        {
            ViewBag.ProductCategories = new SelectList(obj.listLoaiSP(), "id", "tieuDe");
            int check = obj.deleteIamge(model.id);
            if (check != null)
            {
                obj.deleteProducts(model.id);
            }
            else
            {
                ViewBag.thongBao = "Xóa không thành công, bạn phải xóa hình";
            }
            return RedirectToAction("Index");
        }

    }
}