using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_BanDT.Models.csdl
{
    public class LoaiSanPham : DungChung
    {
        public int id { get; set; }
        [Required]
        [StringLength(150)]
        public string tieuDe { get; set; }
        public string MaSanPham { get; set; }
        public string moTa { get; set; }
        public string icon { get; set; }
        [StringLength(550)]
        public string SeoTieuDe { get; set; }
        [StringLength(250)]
        public string SeoMoTa { get; set; }
        [StringLength(250)]
        public string SeoTuKhoa { get; set; }
        public string biDanh { get; set; }
      

    }
}