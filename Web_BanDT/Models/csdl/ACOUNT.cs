using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_BanDT.Models.csdl
{
    public class ACOUNT
    {
        [Required(ErrorMessage = "Tên tài khoản bắt buộc phải nhập.")]
        [StringLength(50, ErrorMessage = "Tên đăng nhập không được quá 50 ký tự.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Mật khẩu đăng nhập là trường bắt buộc.")]
        [StringLength(50, ErrorMessage = "Mật khẩu đăng nhập không được quá 50 ký tự.")]
        public string passWord { get; set; }

        public int role { get; set; }
    }
}