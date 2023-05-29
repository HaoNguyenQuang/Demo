using ThucTapChuyenMon.Models;
using Microsoft.AspNetCore.Mvc;
using ThucTapChuyenMon.Models.Authentication;
namespace ThucTapChuyenMon.Controllers
{
	public class DangNhapController : Controller
	{
        QltvApiContext db = new QltvApiContext();
        [HttpGet]
        public IActionResult DangNhap()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }
        [HttpPost]
        public IActionResult DangNhap(TaiKhoan user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.TaiKhoans.Where(x => x.TaiKhoan1 == user.TaiKhoan1 && x.MatKhau == user.MatKhau).FirstOrDefault();
                var k = db.DocGia.Where(x => x.TaiKhoan == user.TaiKhoan1).FirstOrDefault();
                var l = db.NhanViens.Where(x => x.TaiKhoan == user.TaiKhoan1).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.TaiKhoan1.ToString());
                    HttpContext.Session.SetString("Password", u.MatKhau.ToString());
                    HttpContext.Session.SetString("LoaiTaiKhoan", u.MaRole.ToString());
                    if (k != null)
                    {
                        HttpContext.Session.SetString("IDCustomer", k.MaDocGia.ToString());
                        HttpContext.Session.SetString("Name", k.TenDocGia.ToString());
                        HttpContext.Session.SetString("Phone", k.SoDienThoai.ToString());
                        HttpContext.Session.SetString("Address", k.DiaChi.ToString());
                        HttpContext.Session.SetString("Email", k.Email.ToString());
                        HttpContext.Session.SetString("Gender", k.GioiTinh.ToString());
                        HttpContext.Session.SetString("Birthday", k.NgaySinh.ToString("yyyy-MM-dd"));



                    }
                    if (l != null)
                    {
                        HttpContext.Session.SetString("IDNhanVien", l.MaNhanVien.ToString());
                        HttpContext.Session.SetString("Name", l.HoTen.ToString());
                        HttpContext.Session.SetString("Address", l.DiaChi.ToString());
                        HttpContext.Session.SetString("Birth", l.NgaySinh.ToString());
                        HttpContext.Session.SetString("Email", l.Email.ToString());
                        HttpContext.Session.SetString("Phone", l.SoDienThoai.ToString());
                        HttpContext.Session.SetString("Gender", l.GioiTinh.ToString());

                    }
                    //Nhân viên
                    if (u.MaRole == "RL01")
                    {
                        return RedirectToAction("Sach", "Admin");
                    }
                    //Khách hàng
                    else if (u.MaRole == "RL02")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.ThongBao = "Tài khoản hoặc mật khẩu chưa chính xác";
                }
            }
            return View(user);

        }
    }
}
