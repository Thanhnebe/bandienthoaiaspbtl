using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_BanDT.Models.csdl
{
    public class Category: DungChung
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(150)]
        public string TieuDe { get; set; }
        public string MieuTa { get; set; }
        [StringLength(150)]
        public string SeoTieuDe { get; set; }
        [StringLength(150)]
        public string SeoMoTa { get; set; }
        public string biDanh { get; set; }
        [StringLength(150)]
        public string SeoTuKhoa { get; set; }
        public bool isActive { get; set; }
        public int idNhanVien { get; set; }
        public string tenNhanVien { get; set; }



    }
}