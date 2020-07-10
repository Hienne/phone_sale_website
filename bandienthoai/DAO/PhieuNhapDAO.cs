using bandienthoai.Entities;
using bandienthoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.DAO
{
    public class PhieuNhapDAO
    {
        BanDienThoaiContext db = new BanDienThoaiContext();

        public List<PhieuNhap> getPNInMon()
        {
            return db.PhieuNhaps.Select(x => x).Where(x => x.NgayNhap.Month == DateTime.Now.Month
                        && x.NgayNhap.Year == DateTime.Now.Year).ToList();
        }

        public ChitietPN getChiTietPN(int id)
        {
            var pn = db.PhieuNhaps.Find(id);
            var ct = db.ChiTietPhieuNhaps.SingleOrDefault(x => x.MaPN == pn.MaPN);
            var ctpn = new ChitietPN();
            ctpn.MaPN = pn.MaPN;
            ctpn.NCC = pn.NhaCungCap.TenNCC;
            ctpn.NgayNhap = pn.NgayNhap;
            ctpn.SanPham = ct.SanPham.TenSP;
            ctpn.SoLuong = ct.SoLuongNhap;
            ctpn.DonGia = ct.DonGiaNhap;

            return ctpn;
        }
    }
}