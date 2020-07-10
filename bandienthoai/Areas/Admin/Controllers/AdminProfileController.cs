using bandienthoai.DAO;
using bandienthoai.Entities;
using bandienthoai.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class AdminProfileController : Controller
    {
        private BanDienThoaiContext db = new BanDienThoaiContext();

        public ActionResult ProfileById(int id)
        {
            var ndDAO = new NguoiDungDAO();
            var nguoidung = ndDAO.getById(id);
            return View(nguoidung);
        }

        //GET list Profile
        public ActionResult AllProfile()
        {
            var ndDAO = new NguoiDungDAO();
            return View(ndDAO.getAllAdmin());
        }
        // GET: Admin/AdminProfile
        public ActionResult Profile()
        {
            var ndDAO = new NguoiDungDAO();
            var nguoidung = ndDAO.getByTaiKhoan(Session["TAIKHOAN"].ToString());
            return View(nguoidung);
        }

        //Dang xuat
        public ActionResult Logout()
        {
            Session["TAIKHOAN"] = null;
            Session["HINHANH"] = null;
            Session.Clear();

            return RedirectToAction("Login", "NguoiDung", new { area = ""});
        }

        //tao tai khoan
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SignupModel model)
        {
            var ndDAO = new NguoiDungDAO();
            if (ModelState.IsValid)
            {
                if (ndDAO.checkData(model))
                {
                    ndDAO.InsertAdmin(model);
                    return RedirectToAction("AllProfile");
                }
                else
                    ModelState.AddModelError("", "Đăng ký không thành công, tài khoản hoặc số điện thoại đã tồn tại");

            }

            return View(model);
        }

        //chinh sua
        public ActionResult Edit()
        {
            var ndDAO = new NguoiDungDAO();
            var nguoiDung = ndDAO.getByTaiKhoan(Session["TAIKHOAN"].ToString());
            return View(nguoiDung);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                var ndDAO = new NguoiDungDAO();
                

                var nd = db.NguoiDungs.Find(nguoiDung.MaNguoiDung);

                if (nguoiDung.UploadHinhAnh != null)
                {
                    string fileName = Path.GetFileName(nguoiDung.UploadHinhAnh.FileName);
                    string filePath = "~/Assets/Admin/img/" + fileName;
                    nguoiDung.UploadHinhAnh.SaveAs(Server.MapPath(filePath));

                    nd.HinhAnh = fileName;
                }

                ndDAO.Edit(nguoiDung);
                db.SaveChanges();

                return RedirectToAction("Profile");
            }
            return View(nguoiDung);
        }



        
    }
}