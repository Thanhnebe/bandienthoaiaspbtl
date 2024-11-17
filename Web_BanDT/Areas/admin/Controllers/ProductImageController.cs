using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanDT.Models.connect;
using Web_BanDT.Models.csdl;

namespace Web_BanDT.Areas.admin.Controllers
{
    public class ProductImageController : Controller
    {
        // GET: admin/ProductImage/delete
        CNImageProduct obj = new CNImageProduct();
        public ActionResult Index(int id)
        {
            if (Session["username"] == null)
            {
                return Redirect("/taiKhoan/DangNhap");
            }
            else
            {
                var items = obj.ListIamge(id);
                ViewBag.productId = id;
                return View(items);

            }
        
        }
        //[HttpPost]
        public ActionResult AddImage(int productId, string url)
        {
            ProductImage ImageSP = new ProductImage();
            ImageSP.ProductId = productId;
            ImageSP.image = url;
            ImageSP.idDefault = false;
            obj.InsertProductImages(ImageSP.ProductId, ImageSP.image, ImageSP.idDefault);
            return Json(new { Success = true });
        }
        //[HttpPost]
        public ActionResult delete(int id)
        {
            obj.deleteIamge(id);
            return View("Index");
        }

    }
}