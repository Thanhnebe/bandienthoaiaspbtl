using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_BanDT.Models.csdl
{
    public class NHANVIEN
    {
 
        public int ID { get; set; }

        [Required(ErrorMessage = "Tên nhân viên bắt buộc phải nhập.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Tên nhân viên có ít nhất 2 ký tự và nhiều nhất 50 ký tự.")]
        public string tenNhanVien { get; set; }
        
        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [Range(0, double.MaxValue, ErrorMessage = "Số điện thoại không được âm.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại có ít nhất 11 số.")]
        public string soDienThoai { get; set; }

        [Required(ErrorMessage = "Ngày sinh bắt buộc phải nhập.")]
        [Range(typeof(DateTime), "1/1/1900", "12/12/2023", ErrorMessage = "Ngày sinh không hợp lệ.")]
        public DateTime ngaySinh { get; set; }

        public int idPhanQuyen { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Địa chỉ có ít nhất 2 ký tự và nhiều nhất 100 ký tự.")]
        public string diaChi { get; set; }
  
        [Required(ErrorMessage = "Tên tài khoản bắt buộc phải nhập.")]
        [StringLength(50, ErrorMessage = "Tên đăng nhập không được quá 50 ký tự.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Mật khẩu đăng nhập là trường bắt buộc.")]
        [StringLength(50, ErrorMessage = "Mật khẩu đăng nhập không được quá 50 ký tự.")]
        public string passWord {  get; set; }

        [Required(ErrorMessage = "Xác nhận mật khẩu là trường bắt buộc.")]
        [Compare("passWord", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp.")]
        public string confirmPassword { get; set; }

        public string tenQuyen { get; set; }
    }
}