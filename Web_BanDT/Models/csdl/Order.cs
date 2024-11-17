using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_BanDT.Models.csdl
{
    public class Order:DungChung
    {
        public int Id { get; set; }
        [Required]
        public string MaSanPham { get; set; }
        [Required(ErrorMessage ="Tên không được để trống")]
        public string TenKh { get; set; }
        [Required(ErrorMessage ="Số điện thoại không được để trống")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Địa chỉ không được để trống")]
        public string address { get; set; }
        public decimal tongSL { get; set; }
        public decimal soLuong { get; set; }
    }
}