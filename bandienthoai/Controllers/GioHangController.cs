using bandienthoai.DAO;
using bandienthoai.Entities;
using bandienthoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Controllers
{
    public class GioHangController : BaseController
    {
        public BanDienThoaiContext db = new BanDienThoaiContext();

        // GET: GioHang
        public ActionResult Index()
        {
            NguoiDungDAO ndDAO = new NguoiDungDAO();
            GioHangDAO ghDAO = new GioHangDAO();

            NguoiDung nd = ndDAO.getByTaiKhoan(Session["TAIKHOAN"].ToString());
            Session["GIOHANG"] = ghDAO.getGioHangByND(nd.MaNguoiDung);

            int tongDDH = ghDAO.getTongSPByND(nd.MaNguoiDung);
            int tongGTDDH = ghDAO.getTongGTDDHByND(nd.MaNguoiDung);
            Session.Add("DDH", tongDDH);
            Session.Add("GIATRIDDH", tongGTDDH);

            return View((List<GioHangModel>) Session["GIOHANG"]);

        }

        public ActionResult ChinhSua(int idDDH, int idCT)
        {
            var ghDAO = new GioHangDAO();
            return View(ghDAO.getItemGH(idCT, idDDH));
        }

        [HttpPost]
        public ActionResult ChinhSua(GioHangModel model)
        {
            GioHangDAO ghDAO = new GioHangDAO();
            ghDAO.updateGH(model.MaCHTDDH, model.SoLuong);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteItemGH(int idSP, int idDDH)
        {
            GioHangDAO ghDAO = new GioHangDAO();
            NguoiDungDAO ndDAO = new NguoiDungDAO();
            NguoiDung nd = ndDAO.getByTaiKhoan(Session["TAIKHOAN"].ToString());
            ghDAO.deleteGH(idSP, idDDH, (List<GioHangModel>) Session["GIOHANG"]);

            return RedirectToAction("Index");
        }

        public ActionResult AddSP(int idSP)
        {
            List<GioHangModel> gh = (List<GioHangModel>)Session["GIOHANG"];
            NguoiDungDAO ndDAO = new NguoiDungDAO();
            var ghDAO = new GioHangDAO();
            NguoiDung nd = ndDAO.getByTaiKhoan(Session["TAIKHOAN"].ToString());
            Session["GIOHANG"] = ghDAO.addGH(nd.MaNguoiDung, idSP, gh);

            return RedirectToAction("Index");
        }

        public ActionResult ThanhToan()
        {
            var listGH = (List<GioHangModel>)Session["GIOHANG"];
            ViewBag.GioHang = listGH;
            DonDatHang ddh = db.DonDatHangs.Find(listGH[0].MaDDH);

            return View(ddh);
        }

        [HttpPost]
        public ActionResult ThanhToan(DonDatHang ddh)
        {
            var listGH = (List<GioHangModel>)Session["GIOHANG"];
            var item = db.DonDatHangs.Find(ddh.MaDDH);
            item.DiaChiGiao = ddh.DiaChiGiao;
            item.MaTrangThai = 1;
            item.NgayDat = DateTime.Now;
            db.SaveChanges();


            //chua fix dk
            //foreach(var a in listGH)
            //{
            //    SanPham sp = db.SanPhams.Find(a.MaSP);
            //    sp.SLTon -= a.SoLuong;
            //    sp.SoLanMua += a.SoLuong;

            //    db.SaveChanges();
            //}

            

            return RedirectToAction("Index");
        }
    }
}