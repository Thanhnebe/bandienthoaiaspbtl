using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanDT.Models.connect;
using Web_BanDT.Models.EF;


namespace Web_BanDT.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private WEBSITE_BANHANGEntities1 db = new WEBSITE_BANHANGEntities1();
        public ActionResult Index()
        {
            var item = db.TB_PRODUCT.ToList();  
            return View(item);
        }
        //Tìm Theo mã sản phẩm
        public ActionResult productCategory(int? id, string biDanh)
        {
            var items = db.TB_PRODUCT.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.ProductCategoryId == id).ToList();
            }
            var cate = db.tb_LoaiSanPham.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.tieuDeLSP;
            }

            ViewBag.CateId = id;
            return View(items);
        }
        public ActionResult partial_ItemSP()
        {

            var items = db.TB_PRODUCT.Where(x => x.isHome == "True").Take(12).ToList();
            return PartialView(items);
        }
        public ActionResult partial_ProductSale()
        {
            var items = db.TB_PRODUCT.Where(x => x.isSale == "True").Take(12).ToList();
            return PartialView(items);
           
        }
        public ActionResult DetailSP(string biDanh, int id)
        {
            var item = db.TB_PRODUCT.Find(id);
            if (item != null)
            {
                db.TB_PRODUCT.Attach(item);
                //item.ViewCount = item.ViewCount + 1;
                //db.Entry(item).Property(x => x.ViewCount).IsModified = true;
                db.SaveChanges();
            }

            return View(item);
        }
    }
}