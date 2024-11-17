using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web_BanDT.Models.csdl;
using Web_BanDT.Models.connect;

namespace Web_BanDT.Controllers
{
    public class taiKhoanController : Controller
    {
        // GET: taiKhoan

        CNTaiKhoanKH obj = new CNTaiKhoanKH();
        CNTaiKhoan objNV = new CNTaiKhoan();

        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("DangNhap");
            }
            else
            {
                return View();

            }

        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string username, string passWord)
        {
            var check = obj.checkTK(username, passWord);
            if (check.userName !=null && check.passWord !=null)
            {
                if (check.role == 1)
                {
                    var tkNhanVien = objNV.checkTKNV(username, passWord);
                    Session["username"] = tkNhanVien;
                    return RedirectToAction("Index", "Category", new { area = "admin" });
                }
                else if (check.role == 0)
                {
                    var tkKhachHang = obj.user(username, passWord);
                    Session["username"] = tkKhachHang;
                    return RedirectToAction("Index", "Home");
                }
                return View();  
            }
            else
            {
                ViewBag.thongBao = "Thông tin tài khoản mật khẩu không chính xác";
                return View();
            }
        }

        public ActionResult DangXuat()
        {
            // xoa session
            Session.Remove("username");
            // xoa cokkie
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhap");

        }
        public ActionResult dangKy()
        {

            return View();
        }
        [HttpPost]
        public ActionResult dangKy(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                obj.themKH(kh);
                return RedirectToAction("DangNhap", "taiKhoan");
            }
            else
            {
                ViewBag.thongbao = "Ban chưa đăng ký thành công !. Thông tin không chính xác";
                return View();

            }
        }



    }
}