using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanDT.Models.csdl
{
    public class postBaiViet : DungChung
    {
        public int id { get; set; }
        public string tieuDe { get; set; }
        public string ChiTiet { get; set; }
        public string moTa { get; set; }
        public string image { get; set; }
        public int theLoai { get; set; }
        public string SeoTieuDe { get; set; }
        public string SeoMoTa { get; set; }
        public string SeoTuKhoa { get; set; }
        public string biDanh { get; set; }
        public bool isActive { get; set; }
    }
}