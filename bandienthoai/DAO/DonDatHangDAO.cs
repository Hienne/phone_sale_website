using bandienthoai.Entities;
using bandienthoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.DAO
{
    public class DonDatHangDAO
    {
        BanDienThoaiContext db = new BanDienThoaiContext();

        public List<DonDatHang> getDDHInMon()
        {
            return db.DonDatHangs.Select(x => x).Where(x => x.NgayDat.Month == DateTime.Now.Month 
                    && x.NgayDat.Year == DateTime.Now.Year).ToList();
        }

        public List<DonDatHang> getDDHInDay()
        {
            return db.DonDatHangs.Select(x => x).Where(x => x.NgayDat.Month == DateTime.Now.Month
                    && x.NgayDat.Year == DateTime.Now.Year && x.NgayDat.Day == 4).ToList();
        }

        public List<ChitietDDH> getChiTietDDH(int idDDH)
        {
            List<ChiTietDonDatHang> listDDH = db.ChiTietDonDatHangs.Select(x => x).Where(x => x.MaDDH == idDDH).ToList();
            List<ChitietDDH> list = new List<ChitietDDH>();
            foreach(var a in listDDH)
            {
                ChitietDDH ct = new ChitietDDH();
                ct.MaDDH = a.MaDDH;
                ct.NgayDat = db.DonDatHangs.SingleOrDefault(x => x.MaDDH == a.MaDDH).NgayDat;
                ct.SanPham = a.SanPham.TenSP;
                ct.SoLuong = a.SoLuong;
                ct.DonGia = a.DonGia;
                ct.DiaChiGiao = db.DonDatHangs.SingleOrDefault(x => x.MaDDH == a.MaDDH).DiaChiGiao;

                ct.NguoiDung = db.DonDatHangs.SingleOrDefault(x => x.MaDDH == a.MaDDH).NguoiDung.HoTen;
                //ct.NguoiDung = db.NguoiDungs.SingleOrDefault(x => x.MaNguoiDung == a.DonDatHang.MaNguoiDung).HoTen;

                list.Add(ct);
            }

            return list;
        }

        //public ChitietDDH getChiTietDDH(int id)
        //{
        //    var ddh = db.DonDatHangs.Find(id);
        //    List<ChiTietDonDatHang> listDDH = db.ChiTietDonDatHangs.Select(x => x).Where(x => x.MaDDH == id).ToList();


        //    var ct = db.ChiTietDonDatHangs.SingleOrDefault(x => x.MaDDH == ddh.MaDDH);
        //    var ctddh = new ChitietDDH();
        //    ctddh.DiaChiGiao = ddh.DiaChiGiao;
        //    ctddh.MaDDH = ddh.MaDDH;
        //    ctddh.NgayDat = ddh.NgayDat;
        //    ctddh.NguoiDung = ddh.NguoiDung.TaiKhoan;
        //    ctddh.SanPham = ct.SanPham.TenSP;
        //    ctddh.SoLuong = ct.SoLuong;
        //    ctddh.DonGia = ct.DonGia;
        //    return ctddh;
        //}
    }
}