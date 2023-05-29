using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucTapChuyenMon.Models;

namespace ThucTapChuyenMon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanAPIController : ControllerBase
    {
        QltvApiContext db = new QltvApiContext();

        //Đăng Ký
        [HttpPost]
        [Route("DangKy")]
        public bool DangKy(String MaDocGia, String TaiKhoan,
            String Email, String MatKhau)
        {
            TaiKhoan taikhoan = new TaiKhoan();
            taikhoan.TaiKhoan1 = TaiKhoan;
            taikhoan.MatKhau = MatKhau;
            taikhoan.Email = Email;
            taikhoan.MaRole = "RL02";
            db.TaiKhoans.Add(taikhoan);
            db.SaveChanges();

            DocGia khach = new DocGia();
            khach.MaDocGia = MaDocGia;
            khach.TenDocGia = "";
            khach.GioiTinh = "";
            khach.SoDienThoai = 0;
            khach.DiaChi = "";
            khach.NgaySinh = DateTime.Now;
            khach.Email = Email;           
            khach.TaiKhoan = TaiKhoan;
            db.DocGia.Add(khach);

            db.SaveChanges();
            return true;
        }

        //Cập nhật khách hàng
        [HttpPut]
        [Route("CapNhatKhachHang")]
        public bool UpdateProfile(string makhach, string hovaten, string sodienthoai, string diachi, string email, string gioitinh, DateTime ngaysinh)
        {
            QltvApiContext dbCustomer = new QltvApiContext();
            //Lấy mã khách đã có
            DocGia customer = dbCustomer.DocGia.FirstOrDefault(x => x.MaDocGia == makhach);
            if (customer == null) return false;
            //customer.Makhach = id;
            customer.TenDocGia = hovaten;
            customer.SoDienThoai = int.Parse(sodienthoai);
            customer.DiaChi = diachi;
            customer.Email = email;
            customer.GioiTinh = gioitinh;
            customer.NgaySinh = ngaysinh;
            dbCustomer.SaveChanges();
            return true;
        }

        //Đổi mật khẩu
        [HttpPut]
        [Route("DoiMatKhau")]
        public bool ChangePassword(string taikhoan, string matkhau)
        {
            QltvApiContext db = new QltvApiContext();
            //Lấy mã khách đã có
            TaiKhoan tk = db.TaiKhoans.FirstOrDefault(x => x.TaiKhoan1 == taikhoan);
            if (tk == null) return false;
            //customer.Makhach = id;
            tk.MatKhau = matkhau;
            db.SaveChanges();
            return true;
        }
    }
}
