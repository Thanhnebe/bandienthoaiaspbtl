using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_BanDT.Models.csdl
{
    public class product_image: DungChung
    {
        public int id { get; set; }
        public int IDImage { get; set; }
        public string TieuDeLSP {  get; set; }
        public string tieuDe { get; set; }
        public string ChiTiet { get; set; }
        public string image { get; set; }
        public string biDanh { get; set; }
        public string biDanhLoaiSP { get; set; }
        public bool idDefault { get; set; }
        public bool isHome { get; set; }
        public bool isSale { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal pricesale { get; set; }
        public int productCategoryID { get; set; }
        public string SeoTieuDe { get; set; }
        public string SeoMoTa { get; set; }
        public string SeoTuKhoa { get; set; }

    }
}