using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_BanDT.Models.csdl
{
    public class ThongBaoMoi : DungChung
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Bạn không để trống tiêu đề")]
        [StringLength(150)]
        public string tieuDe { get; set; }
        [AllowHtml]// cho phep luu html
        public string ChiTiet { get; set; }
        public string moTa { get; set; }
        public string image { get; set; }
        public int theLoai { get; set; }
        public string SeoTieuDe { get; set; }
        public string SeoMoTa { get; set; }
        public string SeoTuKhoa { get; set; }
        public string biDanh { get; set; }
        public int Categoryld { get; set; }
        public int idNhanVien { get; set; }
        public bool isActive { get; set; }

    }
}