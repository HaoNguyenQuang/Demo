using ThucTapChuyenMon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThucTapChuyenMon.Models.Authentication;

namespace ThucTapChuyenMon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QltvApiContext db = new QltvApiContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public int splitId(string id)
        {
            //KH002 
            string res = id.Substring(2, id.Length - 2);
            return int.Parse(res);
        }

        public IActionResult Index()
        {
            //Xử lý giỏ hàng
            //Kiểm tra người dùng đăng nhập chưa
            string taiKhoan = HttpContext.Session.GetString("UserName");
            //đã đăng nhập
            if (taiKhoan != null)
            {
                //Lấy id khách hàng thông qua tài khoản
                string getCustomerId = db.DocGia.FirstOrDefault(x => x.TaiKhoan == taiKhoan).MaDocGia;
                //Kiểm tra có tồn tại hóa đơn nhưng chưa thanh toán
                var checkPhieuMuon = db.PhieuMuons.FirstOrDefault
                    (x => x.TinhTrangPhieuMuon == "Chưa mượn" && x.MaDocGia == getCustomerId);
                //Lấy mã hóa đơn
                string maHoaDon = "";
                if (checkPhieuMuon != null)
                {
                    maHoaDon = checkPhieuMuon.MaPhieuMuon;
                }
                if (maHoaDon != "")
                {
                    ViewBag.checkHD = 1; // đã có hóa đơn
                    ViewBag.maHDB = maHoaDon;
                }
                else
                {
                    var lstPhieuMuon = db.PhieuMuons.ToList();
                    int lastIdHoaDonBan = splitId(lstPhieuMuon.OrderByDescending(x => splitId(x.MaPhieuMuon))
                        .FirstOrDefault().MaPhieuMuon.ToString()) + 1;
                    ViewBag.checkHD = 0;
                    ViewBag.maHDB = "PM" + lastIdHoaDonBan.ToString();
                }
                //Lấy id khách hàng
                ViewBag.maKH = getCustomerId;
            }

            //list book
            var sach = db.Saches.ToList();
            return View(sach);
        }
        public IActionResult LienHe()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ChiTietSanPham(String MaSp)
        {
            //Xử lý giỏ hàng
            //Kiểm tra người dùng đăng nhập chưa
            string taiKhoan = HttpContext.Session.GetString("UserName");
            //đã đăng nhập
            if (taiKhoan != null)
            {
                //Lấy id khách hàng thông qua tài khoản
                string getCustomerId = db.DocGia.FirstOrDefault(x => x.TaiKhoan == taiKhoan).MaDocGia;
                //Kiểm tra có tồn tại hóa đơn nhưng chưa thanh toán
                var checkPhieuMuon = db.PhieuMuons.FirstOrDefault
                    (x => x.TinhTrangPhieuMuon == "Chưa mượn" && x.MaDocGia == getCustomerId);
                //Lấy mã hóa đơn
                string maHoaDon = "";
                if (checkPhieuMuon != null)
                {
                    maHoaDon = checkPhieuMuon.MaPhieuMuon;
                }
                if (maHoaDon != "")
                {
                    ViewBag.checkHD = 1; // đã có hóa đơn
                    ViewBag.maHDB = maHoaDon;
                }
                else
                {
                    var lstPhieuMuon = db.PhieuMuons.ToList();
                    int lastIdHoaDonBan = splitId(lstPhieuMuon.OrderByDescending(x => splitId(x.MaPhieuMuon))
                        .FirstOrDefault().MaPhieuMuon.ToString()) + 1;
                    ViewBag.checkHD = 0;
                    ViewBag.maHDB = "PM" + lastIdHoaDonBan.ToString();
                }
                //Lấy id khách hàng
                ViewBag.maKH = getCustomerId;
            }
            var sanPham = db.Saches.SingleOrDefault(x => x.MaSach == MaSp);
            return View(sanPham);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Loi404()
        {
            return View();
        }
    }
}