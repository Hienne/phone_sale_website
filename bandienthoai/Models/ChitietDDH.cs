using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace bandienthoai.Models
{
    public class ChitietDDH
    {
        [DisplayName("Mã DDH")]
        public int MaDDH { get; set; }

        [DisplayName("Ngày đặt")]
        public DateTime NgayDat { get; set; }

        [DisplayName("Địa chỉ giao")]
        public string DiaChiGiao { get; set; }

        [DisplayName("Người đặt")]
        public string NguoiDung { get; set; }

        [DisplayName("Sản phẩm")]
        public string SanPham { get; set; }

        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }

        [DisplayName("Đơn giá")]
        public int DonGia { get; set; }

    }
}