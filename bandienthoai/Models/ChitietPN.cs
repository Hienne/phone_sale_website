using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace bandienthoai.Models
{
    public class ChitietPN
    {
        [DisplayName("Mã phiếu nhập")]
        public int MaPN { get; set; }

        [DisplayName("Ngày nhập")]
        public DateTime NgayNhap { get; set; }

        [DisplayName("Nhà cung cấp")]
        public string NCC { get; set; }

        [DisplayName("Số lượng nhập")]
        public int SoLuong { get; set; }

        [DisplayName("Đơn giá nhập")]
        public int DonGia { get; set; }

        [DisplayName("Sản phẩm")]
        public string SanPham { get; set; }
    }
}