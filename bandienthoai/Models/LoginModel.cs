using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Yêu cầu nhập tài khoản")]
        public string taikhoan { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string matkhau { get; set; }

        public bool rememberMe { get; set; }
    }
}