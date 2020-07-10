using bandienthoai.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Controllers
{
    public class TrangChuController : Controller
    {
        public BanDienThoaiContext db = new BanDienThoaiContext();

        // GET: TrangChu
        public ActionResult Index()
        {
            return View(db.SanPhams.ToList());
        }
    }
}