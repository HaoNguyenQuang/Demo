using ThucTapChuyenMon.Models;
using Microsoft.AspNetCore.Mvc;
using ThucTapChuyenMon.Models.Authentication;
namespace ThucTapChuyenMon.Controllers
{
    public class TatCaSachController : Controller
    {
        QltvApiContext db = new QltvApiContext();
        public int splitId(string id)
        {
            //KH002 
            string res = id.Substring(2, id.Length - 2);
            return int.Parse(res);
        }
        public IActionResult TatCaSach()
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
            var sach = db.Saches.ToList();
            return View(sach);
        }
    }
}
