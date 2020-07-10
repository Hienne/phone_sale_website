using bandienthoai.DAO;
using bandienthoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bandienthoai.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var ndDAO = new NguoiDungDAO();
                var result = ndDAO.Login(model.taikhoan, model.matkhau);
                if (result)
                {
                    var taikhoan = model.taikhoan;
                    Session.Add("TAIKHOAN", taikhoan);
                    return RedirectToAction("Index", "test");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công.");
                }
            }
            return View("Index");
        }

    }
}