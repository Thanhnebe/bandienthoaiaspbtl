using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Web_BanDT.Models;
using Web_BanDT.Models.connect;
using Web_BanDT.Models.csdl;
using Web_BanDT.Models.EF;

namespace Web_BanDT.Controllers
{
    public class ShoppingCartController : Controller
    {
        private WEBSITE_BANHANGEntities1 db = new WEBSITE_BANHANGEntities1();
        KhachHang KH = (KhachHang)System.Web.HttpContext.Current.Session["username"];

        // GET: ShoppingCart
        public ActionResult Index()
        {

            shoppingCart cart = (shoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }

        //Đếm số lượng sản phẩm có trong giỏ hàng
        /* Cho phép yêu cầu JSON từ các trang web ở các tên miền khác.
        bạn có thể gửi yêu cầu AJAX từ một tên miền khác đến hành động điều khiển trong ứng dụng 
        và nhận được phản hồi JSON.*/
        public ActionResult ShowCount()
        {
            shoppingCart cart = (shoppingCart)Session["Cart"];
            if (cart != null)
            {
                return Json(new { Count = cart.Items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0 }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ThemGioHang(int id, int quantity)
        {
            //Khởi tạo một đối tượng rỗng
            var sp = new { Success = false, msg = "", code = -1, Count = 0 };
            var db = new WEBSITE_BANHANGEntities1();
            var checkProduct = db.TB_PRODUCT.FirstOrDefault(x => x.ID == id);

            if (checkProduct != null)
            {
                shoppingCart cart = (shoppingCart)Session["Cart"];
                //khởi tạo giỏ hàng
                if (cart == null)
                {
                    cart = new shoppingCart();
                }
                //thêm từng sản phẩm  vào giỏ hàng
                ShoppingCartItem item = new ShoppingCartItem
                {
                    ProductId = checkProduct.ID,
                    ProductName = checkProduct.tieuDe,
                    CategoryName = checkProduct.tb_LoaiSanPham.tieuDeLSP,
                    Alias = checkProduct.biDanh,
                    Quantity = quantity
                };
                if (checkProduct.tb_ProductImage.FirstOrDefault(x => x.idDefault == "True") != null)
                {
                    item.ProductImg = checkProduct.tb_ProductImage.FirstOrDefault(x => x.idDefault == "True").image;
                }
                item.Price = (decimal)checkProduct.Price;
                //kiểm tra sp có giảm giá không, nếu có cập nhật lại
                if (checkProduct.Pricesales > 0)
                {
                    item.Price = (decimal)checkProduct.Pricesales;
                }
                item.TotalPrice = item.Quantity * item.Price;
                cart.AddToCard(item, quantity);
                Session["Cart"] = cart;
                sp = new { Success = true, msg = "Thêm sản phẩm vào giở hàng thành công!", code = 1, Count = cart.Items.Count };
            }
            return Json(sp);
        }
        [HttpPost]
        public ActionResult DeleteSP(int id)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };

            shoppingCart cart = (shoppingCart)Session["Cart"];
            if (cart != null)
            {

                var checkProduct = cart.Items.FirstOrDefault(x => x.ProductId == id);
                if (checkProduct != null)
                {
                    cart.remove(id);
                    code = new { Success = true, msg = "", code = 1, Count = cart.Items.Count };
                }
            }
            return Json(code);
        }
        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            shoppingCart cart = (shoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.updateSL(id, quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }

        public ActionResult GioHang()
        {
            shoppingCart cart = (shoppingCart)Session["Cart"];
            if (cart != null)
            {
                return View(cart.Items);
            }
            return PartialView();
        }
        public ActionResult GioHangThanhToan()
        {
            shoppingCart cart = (shoppingCart)Session["Cart"];
            if (cart != null)
            {
                return View(cart.Items);
            }
            return PartialView();
        }


        public ActionResult thanhToan()
        {
            shoppingCart cart = (shoppingCart)Session["Cart"];
            if (cart != null)
            {
                ViewBag.checkThanhToan = cart;
            }
            return View();
        }
        public ActionResult Partial_thanhToan()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Partial_thanhToan(tb_Order TB_order)
        {

            int item = 0;
            if (ModelState.IsValid)
            {
                shoppingCart cart = (shoppingCart)Session["Cart"];
                if (cart != null)
                {
                    tb_Order or = new tb_Order();
                    or.Tenkh = TB_order.Tenkh;
                    or.Phone = TB_order.Phone;
                    or.address = TB_order.address;
                    or.Email = TB_order.Email;
                    cart.Items.ForEach(x => or.tb_orderDeTail.Add(new tb_orderDeTail
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        price = x.Price
                    }));
                    or.CreatedDate = DateTime.Now;
                    or.Craetedby = TB_order.Tenkh;
                    or.idKhacHang = KH.ID;


                    or.tongTien = cart.Items.Sum(x => (x.Price * x.Quantity));
                    Random rd = new Random();
                    or.MaSanPham = "DH" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
                    db.tb_Order.Add(or);
                    item = db.SaveChanges();
                    cart.clearCart();
                    TempData["SuccessMessage"] = "thanh cong";
                    return RedirectToAction("datHangThanhCong");


                }
            }

            return View();
        }

        public ActionResult datHangThanhCong()
        {

            return View();
        }


        public ActionResult kiemTraDonHangDaMua()
        {
            int id = KH.ID;
            var muaHangs = db.tb_Order.Where(x => x.idKhacHang == id).OrderByDescending(x => x.CreatedDate).ToList();
            return View(muaHangs);
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
        [HttpPost]
        public ActionResult HuyDonHang(int id)
        {
            var orderToCancel = db.tb_Order.SingleOrDefault(row => row.ID == id);

            if (orderToCancel != null)
            {
                var orderDetailsToDelete = db.tb_orderDeTail.Where(detail => detail.orderId == id);
                db.tb_orderDeTail.RemoveRange(orderDetailsToDelete);

                db.tb_Order.Remove(orderToCancel);

                db.SaveChanges();

                return RedirectToAction("kiemTraDonHangDaMua");
            }
            else
            {
                return HttpNotFound();
            }
        }


    }

}