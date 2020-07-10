using bandienthoai.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult ChiTiet(int id)
        {
            var spDAO = new SanPhamDAO();
            return View(spDAO.GetSPById(id));
        }

        public PartialViewResult Single_Product_Related()
        {
            var spDAO = new SanPhamDAO();
            return PartialView("Single_Product_Related", spDAO.GetAllSP());
        }
    }
}