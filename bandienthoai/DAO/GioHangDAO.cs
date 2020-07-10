using bandienthoai.Entities;
using bandienthoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bandienthoai.DAO
{
    public class GioHangDAO
    {
        public BanDienThoaiContext db = new BanDienThoaiContext();

        public GioHangModel getItemGH(int idCTDDH, int idDDh)
        {
            var ct = db.ChiTietDonDatHangs.Find(idCTDDH);
            var ddh = db.DonDatHangs.Find(idDDh);
            var item = new GioHangModel();

            item.DonGia = ct.DonGia;
            item.HinhAnh = ct.SanPham.HinhAnh;
            item.MaCHTDDH = ct.MaCTDDH;
            item.MaDDH = ct.MaDDH;
            item.MaSP = ct.MaSP;
            item.NgayDat = ddh.NgayDat;
            item.SoLuong = ct.SoLuong;
            item.TenSP = ct.SanPham.TenSP;

            return item;
        }

        public List<GioHangModel> getGioHangByND(int idND)
        {
            var ddh = db.DonDatHangs.SingleOrDefault(x => x.MaNguoiDung == idND && x.MaTrangThai == 0);
            List<GioHangModel> listGH;

            if (ddh != null)
            {
                List<ChiTietDonDatHang> listCTDDH = db.ChiTietDonDatHangs.Where(x => x.MaDDH == ddh.MaDDH).ToList();
                listGH = new List<GioHangModel>();
                foreach (var a in listCTDDH)
                {
                    var gh = new GioHangModel();

                    gh.TenSP = a.SanPham.TenSP;
                    gh.HinhAnh = a.SanPham.HinhAnh;
                    gh.SoLuong = a.SoLuong;
                    gh.DonGia = a.DonGia;
                    gh.NgayDat = db.DonDatHangs.SingleOrDefault(x => x.MaDDH == a.MaDDH).NgayDat;
                    gh.MaSP = a.MaSP;
                    gh.MaCHTDDH = a.MaCTDDH;
                    gh.MaDDH = a.MaDDH;

                    listGH.Add(gh);
                }
            }
            else
            {
                listGH = new List<GioHangModel>();
            }

            return listGH;
        }

        //get tong so san pham trong don dat hang
        public int getTongSPByND(int idND)
        {
            var ddh = db.DonDatHangs.SingleOrDefault(x => x.MaNguoiDung == idND && x.MaTrangThai == 0);

            int tong = 0;
            if (ddh != null)
            {
                List<ChiTietDonDatHang> listCTDDH = db.ChiTietDonDatHangs.Where(x => x.MaDDH == ddh.MaDDH).ToList();

                foreach (var a in listCTDDH)
                    tong += a.SoLuong;
            }
            else
            {
                tong = 0;
            }

            return tong;
        }
        
        //get tong gia tri don dat hang
        public int getTongGTDDHByND(int idND)
        {
            var ddh = db.DonDatHangs.SingleOrDefault(x => x.MaNguoiDung == idND && x.MaTrangThai == 0);

            int tongGT = 0;
            if (ddh != null)
            {
                List<ChiTietDonDatHang> listCTDDH = db.ChiTietDonDatHangs.Where(x => x.MaDDH == ddh.MaDDH).ToList();

                for (int i = 0; i < listCTDDH.Count; i++)
                {
                    tongGT += listCTDDH[i].DonGia * listCTDDH[i].SoLuong;
                }
            }
            else
            {
                tongGT = 0;
            }

            return tongGT;
        }

        public void deleteGH(int idSP, int idDDH, List<GioHangModel> gh)
        {
            var ctDDH = db.ChiTietDonDatHangs.SingleOrDefault(x => x.MaSP == idSP && x.MaDDH == idDDH);
            var ddh = db.DonDatHangs.Find(idDDH);

            if (gh.Count == 1)
            {
                db.ChiTietDonDatHangs.Remove(ctDDH);
                db.SaveChanges();
                db.DonDatHangs.Remove(ddh);
            }
            else
            {
                db.ChiTietDonDatHangs.Remove(ctDDH);
            }
            
            db.SaveChanges();
        }

        public List<GioHangModel> addGH(int idND, int idSP, List<GioHangModel> gh)
        {
            if (gh.Count != 0)
            {

                if (gh.Exists(x => x.MaSP == idSP))
                {
                    foreach(var item in gh)
                    {
                        if (item.MaSP == idSP)
                        {
                            ChiTietDonDatHang ct = db.ChiTietDonDatHangs.Find(item.MaCHTDDH);
                            ct.SoLuong += 1;
                        }
                    }
                }
                else
                {
                    var item = new ChiTietDonDatHang();
                    int maxID = db.ChiTietDonDatHangs.Select(x => x.MaCTDDH).Max();

                    item.MaSP = idSP;
                    item.MaDDH = gh[0].MaDDH;
                    item.MaCTDDH = maxID + 1;
                    item.SoLuong = 1;
                    item.DonGia = db.SanPhams.Find(idSP).DonGia;

                    db.ChiTietDonDatHangs.Add(item);
                }
            }
            else
            {
                var itemDDH = new DonDatHang();
                int maxIDDDH = db.DonDatHangs.Select(x => x.MaDDH).Max();

                itemDDH.MaDDH = maxIDDDH + 1;
                itemDDH.MaNguoiDung = idND;
                itemDDH.MaTrangThai = 0;
                itemDDH.NgayDat = DateTime.Now;
                itemDDH.DiaChiGiao = "";
                db.DonDatHangs.Add(itemDDH);
                db.SaveChanges();

                var itemCHTHD = new ChiTietDonDatHang();
                int maxIDCTHD = db.ChiTietDonDatHangs.Select(x => x.MaCTDDH).Max();

                itemCHTHD.MaSP = idSP;
                itemCHTHD.MaDDH = itemDDH.MaDDH;
                itemCHTHD.MaCTDDH = maxIDCTHD + 1;
                itemCHTHD.SoLuong = 1;
                itemCHTHD.DonGia = db.SanPhams.Find(idSP).DonGia;
                db.ChiTietDonDatHangs.Add(itemCHTHD);
                db.SaveChanges();
            }

            db.SaveChanges();

            return gh;
        }

        public void updateGH(int idCTDDH, int soluong)
        {
            var ct = db.ChiTietDonDatHangs.Find(idCTDDH);
            ct.SoLuong = soluong;

            db.SaveChanges();
        }
    }
}