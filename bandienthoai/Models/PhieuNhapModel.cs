using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Models
{
    public class PhieuNhapModel
    {
        [DisplayName("Sản phẩm")]
        public int MaSP { get; set; }

        [DisplayName("Đơn giá nhập")]
        [Required(ErrorMessage = "Chưa nhập đơn giá nhập")]
        public int DonGiaNhap { get; set; }

        [DisplayName("Số lượng nhập")]
        [Required(ErrorMessage = "Chưa nhập số lượng nhập")]
        public int SoLuongNhap { get; set; }

        [DisplayName("Nhà cung cấp")]
        public int MaNCC { get; set; }

        [Required(ErrorMessage = "Chưa nhập ngày nhập")]
        [DisplayName("Ngày nhập")]
        [DataType(DataType.Date)]
        public DateTime NgayNhap { get; set; }
    }
}