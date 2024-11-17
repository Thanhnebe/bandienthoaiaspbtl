using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanDT.Models.csdl;
using Web_BanDT.Models.EF;

namespace Web_BanDT.Areas.admin.Controllers
{
    public class ThongTinChiTietDonHangController : Controller
    {
        // GET: admin/ThongTinChiTietDonHang
        private WEBSITE_BANHANGEntities1 db = new WEBSITE_BANHANGEntities1();

        public ActionResult Index(int ?page)
        {
            if (Session["username"] == null)
            {
                return Redirect("/taiKhoan/DangNhap");

            }
            else
            {
                var items = db.tb_Order.OrderByDescending(x => x.CreatedDate).ToList();

                if (page == null)
                {
                    page = 1;
                }
                var pageNumber = page ?? 1;
                var pageSize = 10;
                ViewBag.PageSize = pageSize;
                ViewBag.Page = pageNumber;
                return View(items.ToPagedList(pageNumber, pageSize));

            }

          

        }
        public ActionResult View(int id)
        {
            var item = db.tb_Order.Find(id);
            return View(item);
        }
        public ActionResult Partial_SanPham(int id)
        {
            var item = db.tb_orderDeTail.Where(x => x.orderId == id);
            return PartialView(item);  
        }
    }
}