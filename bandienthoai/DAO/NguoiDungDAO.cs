using bandienthoai.Entities;
using bandienthoai.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace bandienthoai.DAO
{
    public class NguoiDungDAO
    {
        BanDienThoaiContext db = null;

        public NguoiDungDAO()
        {
            db = new BanDienThoaiContext();
        }

        public NguoiDung getByTaiKhoan(string taikhoan)
        {
            return db.NguoiDungs.SingleOrDefault(x => x.TaiKhoan == taikhoan);
        }

        public NguoiDung getById(int id)
        {
            return db.NguoiDungs.Find(id);
        }

        public List<NguoiDung> getAllKhachHang()
        {
            return db.NguoiDungs.Select(x => x).Where(x => x.MaLND == 2).ToList();
        }

        public List<NguoiDung> getAllAdmin()
        {
            return db.NguoiDungs.Select(x => x).Where(x => x.MaLND == 1).ToList();
        }

        public bool Login(string taikhoan, string matkhau)
        {
            var result = db.NguoiDungs.Count(x => x.TaiKhoan == taikhoan && x.MatKhau == matkhau);
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool checkData(SignupModel model)
        {
            foreach(var x in db.NguoiDungs.ToList())
            {
                if (x.TaiKhoan == model.TaiKhoan || x.SDT == model.SDT)
                    return false;
            }
            return true;
        }

        public void InsertAdmin(SignupModel nd)
        {
            NguoiDung nguoiDung = new NguoiDung();
            int maxID = db.NguoiDungs.Select(x => x.MaNguoiDung).Max();

            nguoiDung.MaNguoiDung = maxID + 1;
            nguoiDung.HoTen = nd.HoTen;
            nguoiDung.TaiKhoan = nd.TaiKhoan;
            nguoiDung.MatKhau = nd.MatKhau;
            nguoiDung.DiaChi = nd.DiaChi;
            nguoiDung.Email = nd.Email;
            nguoiDung.SDT = nd.SDT;
            nguoiDung.MaLND = 1;
            nguoiDung.GioiTinh = nd.GioiTinh;
            nguoiDung.NgaySinh = nd.NgaySinh;
            nguoiDung.HinhAnh = "icon-profile-cgv.png";

            db.NguoiDungs.Add(nguoiDung);
            db.SaveChanges();
        }

        public void InsertND(SignupModel nd)
        {
            NguoiDung nguoiDung = new NguoiDung();
            int maxID = db.NguoiDungs.Select(x => x.MaNguoiDung).Max();

            nguoiDung.MaNguoiDung = maxID + 1;
            nguoiDung.HoTen = nd.HoTen;
            nguoiDung.TaiKhoan = nd.TaiKhoan;
            nguoiDung.MatKhau = nd.MatKhau;
            nguoiDung.DiaChi = nd.DiaChi;
            nguoiDung.Email = nd.Email;
            nguoiDung.SDT = nd.SDT;
            nguoiDung.MaLND = 2;
            nguoiDung.GioiTinh = nd.GioiTinh;
            nguoiDung.NgaySinh = nd.NgaySinh;
            nguoiDung.HinhAnh = "icon-profile-cgv.png";

            db.NguoiDungs.Add(nguoiDung);
            db.SaveChanges();
        }

        public void Edit(NguoiDung nd)
        {
            NguoiDung nguoiDung = db.NguoiDungs.Find(nd.MaNguoiDung);
            nguoiDung.HoTen = nd.HoTen;
            nguoiDung.DiaChi = nd.DiaChi;
            nguoiDung.Email = nd.Email;
            nguoiDung.GioiTinh = nd.GioiTinh;
            nguoiDung.NgaySinh = nd.NgaySinh;
            nguoiDung.SDT = nd.SDT;
            nguoiDung.TaiKhoan = nd.TaiKhoan;

            db.SaveChanges();
        }

        
    }
}