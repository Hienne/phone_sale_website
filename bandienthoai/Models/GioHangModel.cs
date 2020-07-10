using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bandienthoai.Models
{
    [Serializable]
    public class GioHangModel
    {
        public int MaSP { get; set; }
        public int MaDDH { get; set; }
        public int MaCHTDDH { get; set; }
        public string HinhAnh { get; set; }
        public string TenSP { get; set; }
        public int DonGia { get; set; }

        [Range(1, 10, ErrorMessage ="Số lượng phải lớn hơn 0 và nhỏ hơn 10")]
        public int SoLuong { get; set; }
        public DateTime NgayDat { get; set; }
    }
}