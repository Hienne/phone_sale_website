using bandienthoai.Entities;
using bandienthoai.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace bandienthoai.DAO
{
    public class SanPhamDAO
    {
        BanDienThoaiContext db = new BanDienThoaiContext();

        public List<SanPham> GetAllSP()
        {
            return db.SanPhams.ToList();
        }

        public SanPham GetSPById(int id)
        {
            return db.SanPhams.Find(id);
        }

        public void CapNhatSLTon(int id, int SLNhap)
        {
           
                SanPham sp = db.SanPhams.Find(id);
                sp.SLTon += SLNhap;
                //db.SaveChanges();
        }

        public SanPham GetSPByName(string name)
        {
            return db.SanPhams.SingleOrDefault(x => x.TenSP == name);
        }

        public void InsertSP(SanPham model)
        {
            int maxIdSP = db.SanPhams.Select(x => x.MaSP).Max();
            model.MaSP = maxIdSP + 1;
            model.SLTon = 0;
            model.SoLanMua = 0;
            db.SanPhams.Add(model);
            db.SaveChanges();
        }

        public void InsertPhieuNhap(PhieuNhapModel model)
        {
                PhieuNhap pn = new PhieuNhap();
                ChiTietPhieuNhap chitietPN = new ChiTietPhieuNhap();
                NhaCungCapDAO nccDAO = new NhaCungCapDAO();

                int maxIdPN = db.PhieuNhaps.Select(x => x.MaPN).Max();
                int maxIdCTPN = db.ChiTietPhieuNhaps.Select(x => x.MaCTPN).Max();

                pn.MaPN = maxIdPN + 1;
                pn.MaNCC = model.MaNCC;
                pn.NgayNhap = model.NgayNhap;
                db.PhieuNhaps.Add(pn);

                chitietPN.MaPN = maxIdPN + 1;
                chitietPN.MaCTPN = maxIdCTPN + 1;
                chitietPN.DonGiaNhap = model.DonGiaNhap;
                chitietPN.SoLuongNhap = model.SoLuongNhap;
                chitietPN.MaSP = model.MaSP;
                db.ChiTietPhieuNhaps.Add(chitietPN);

                //CapNhatSLTon(model.MaSP, model.SoLuongNhap);

                db.SaveChanges();
            
        }
    }
}