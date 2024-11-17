using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BanDT.Models.EF;
using Web_BanDT.App_Start;
namespace Web_BanDT.Areas.admin.Controllers
{
    public class PhanQuyenController : Controller
    {
        //GET: admin/PhanQuyen
       //id = 0
        private WEBSITE_BANHANGEntities1 db = new WEBSITE_BANHANGEntities1();

        [checkQuyenAdmin(idChucNang = 0)]
        public ActionResult DanhSach()
        {
            var items = db.NHANVIENs.ToList();
            return View(items);
        }
        //id =1
        [checkQuyenAdmin(idChucNang = 1)]
        public ActionResult ThemMoi()
        {

            return View();
        }
        //id =2
        [checkQuyenAdmin(idChucNang = 2)]
        public ActionResult CapNhat()
        {

            return View();
        }
        //id =3
        [checkQuyenAdmin(idChucNang = 3)]
        public ActionResult Xoa()
        {
            return View();
        }

    }
}