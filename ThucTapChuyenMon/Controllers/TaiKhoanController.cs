using Microsoft.AspNetCore.Mvc;
using ThucTapChuyenMon.Models.Authentication;
namespace ThucTapChuyenMon.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChiTietTaiKhoan()
        {
            ViewBag.IDCustomer = HttpContext.Session.GetString("IDCustomer");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Phone = HttpContext.Session.GetString("Phone");
            ViewBag.Address = HttpContext.Session.GetString("Address");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Gender = HttpContext.Session.GetString("Gender");
            ViewBag.Birth = HttpContext.Session.GetString("Birthday");

            ViewBag.Username = HttpContext.Session.GetString("UserName");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            return View();
        }

		public IActionResult DangXuat()
		{
			HttpContext.Session.Clear();
			HttpContext.Session.Remove("UserName");
			return RedirectToAction("Index", "Home");
		}
	}
}
