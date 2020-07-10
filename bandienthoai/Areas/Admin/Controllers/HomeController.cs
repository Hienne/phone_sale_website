using bandienthoai.DAO;
using bandienthoai.Entities;
using bandienthoai.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        BanDienThoaiContext db = new BanDienThoaiContext();

        // GET: Admin/Home
        public ActionResult Index()
        {
            var ndDAO = new NguoiDungDAO();
            
            return View(ndDAO.getAllKhachHang());
        }

        //xu ly don dat hang
        public ActionResult getDDHInMon()
        {
            var ddhDAO = new DonDatHangDAO();

            return View(ddhDAO.getDDHInMon());
        }

        public ActionResult AllDDHInDay()
        {
            var ddhDAO = new DonDatHangDAO();

            return View(ddhDAO.getDDHInDay());
        }

        public ActionResult ChiTietDDH(int id)
        {
            var ddhDAO = new DonDatHangDAO();
            return View(ddhDAO.getChiTietDDH(id));
        }


        //su ly phieu nhap
        public ActionResult AllPNInMon()
        {
            var pnDAO = new PhieuNhapDAO();

            return View(pnDAO.getPNInMon());
        }

        public ActionResult ChiTietPN(int id)
        {
            var pnDAO = new PhieuNhapDAO();
            return View(pnDAO.getChiTietPN(id));
        }

        //tao phieu nhap
        public ActionResult CreatePN()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            return View();
        }

        [HttpPost]
        public ActionResult CreatePN(PhieuNhapModel model)
        {
            var spDAO = new SanPhamDAO();
            if (ModelState.IsValid)
            {
                spDAO.InsertPhieuNhap(model);
                return RedirectToAction("AllPNInMon");

            }

            return View(model);
        }

        public ActionResult AllSP()
        {
            return View(db.SanPhams.ToList());
        }

        //tao san pham
        public ActionResult CreateSP()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            ViewBag.MaNSX = new SelectList(db.NhaSanXuats, "MaNSX", "TenNSX");
            return View();
        }

        [HttpPost]
        public ActionResult CreateSP(SanPham model)
        {
            var spDAO = new SanPhamDAO();
            if (ModelState.IsValid)
            {
                //string fileName = Path.GetFileName(model.UploadHinhAnh.FileName);
                //string filePath = "~/Assets/Admin/img/imgSP/" + fileName;
                //model.UploadHinhAnh.SaveAs(Server.MapPath(filePath));

                spDAO.InsertSP(model);
                return RedirectToAction("AllSP");

            }

            return View(model);
        }

    }
}