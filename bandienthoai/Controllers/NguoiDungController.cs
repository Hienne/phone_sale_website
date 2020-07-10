using bandienthoai.DAO;
using bandienthoai.Entities;
using bandienthoai.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Controllers
{
    public class NguoiDungController : Controller
    {
        public BanDienThoaiContext db = new BanDienThoaiContext();

        // GET: NguoiDung
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var ndDAO = new NguoiDungDAO();
                var ghDAO = new GioHangDAO();

                var result = ndDAO.Login(model.taikhoan, model.matkhau);
                if (result)
                {
                    var nguoidung = ndDAO.getByTaiKhoan(model.taikhoan);
                    var taikhoan = model.taikhoan;
                    string hinhanh = nguoidung.HinhAnh;
                    int tongDDH = ghDAO.getTongSPByND(nguoidung.MaNguoiDung);
                    int tongGTDDH = ghDAO.getTongGTDDHByND(nguoidung.MaNguoiDung);

                    Session.Add("TAIKHOAN", taikhoan);
                    Session.Add("HINHANH", hinhanh);
                    Session.Add("DDH", tongDDH);
                    Session.Add("GIATRIDDH", tongGTDDH);

                    NguoiDung nd = ndDAO.getByTaiKhoan(model.taikhoan);
                    Session["GIOHANG"] = ghDAO.getGioHangByND(nd.MaNguoiDung);

                    if (nguoidung.MaLND == 1)
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    else
                        return RedirectToAction("Index", "TrangChu");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công.");
                }
            }
            return View("Login");
        }

        public ActionResult DangXuat()
        {
            Session["TAIKHOAN"] = null;
            Session["HINHANH"] = null;
            Session["GIOHANG"] = null;
            Session["DDH"] = null;
            Session["GIATRIDDH"] = null;
            Session.Clear();

            return RedirectToAction("Login", "NguoiDung");
        }

        public ActionResult TaiKhoan()
        {
            var ndDAO = new NguoiDungDAO();
            var nguoidung = ndDAO.getByTaiKhoan(Session["TAIKHOAN"].ToString());
            return View(nguoidung);
        }

        //tao tai khoan
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(SignupModel model)
        {
            var ndDAO = new NguoiDungDAO();
            if (ModelState.IsValid)
            {
                if (ndDAO.checkData(model))
                {
                    ndDAO.InsertND(model);
                    return RedirectToAction("Login");
                }
                else
                    ModelState.AddModelError("", "Đăng ký không thành công, tài khoản hoặc số điện thoại đã tồn tại");

            }

            return View(model);
        }

        //chinh sua
        public ActionResult ChinhSua()
        {
            var ndDAO = new NguoiDungDAO();
            var nguoiDung = ndDAO.getByTaiKhoan(Session["TAIKHOAN"].ToString());
            return View(nguoiDung);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult ChinhSua(NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                var ndDAO = new NguoiDungDAO();

                var nd = db.NguoiDungs.Find(nguoiDung.MaNguoiDung);

                if (nguoiDung.UploadHinhAnh != null)
                {
                    string fileName = Path.GetFileName(nguoiDung.UploadHinhAnh.FileName);
                    string filePath = "~/Assets/Customer/img/" + fileName;
                    nguoiDung.UploadHinhAnh.SaveAs(Server.MapPath(filePath));
                    nd.HinhAnh = fileName;
                }

                ndDAO.Edit(nguoiDung);
                db.SaveChanges();

                return RedirectToAction("TaiKhoan");
            }
            return View(nguoiDung);
        }
    }
}