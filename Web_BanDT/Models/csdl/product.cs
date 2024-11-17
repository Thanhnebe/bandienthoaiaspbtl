using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_BanDT.Models.csdl
{
    public class product : DungChung
    {
        public int id { get; set; }
        [Required]
        [StringLength(150)]
        [AllowHtml]
        public string tieuDe { get; set; }
        public string productCode { get; set; }
        public int productCategoryID { get; set; }
        [AllowHtml]
        public string ChiTiet { get; set; }
        [AllowHtml]
        public string moTa { get; set; }
        [AllowHtml]
        public int theLoai { get; set; }
        public int quantity { get; set; }
        public string SeoTieuDe { get; set; }

        public string SeoMoTa { get; set; }
        public string SeoTuKhoa { get; set; }
        public decimal price { get; set; }
        public decimal priceSale { get; set; }
        public bool isHome { get; set; }
        public bool isHot { get; set; }
        public bool isfearure { get; set; }
        public bool isSale { get; set; }
        public string biDanh { get; set; }
        public bool isActive { get; set; }

    }
}