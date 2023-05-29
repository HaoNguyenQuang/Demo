using ThucTapChuyenMon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenMon.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachTheoTheLoaiAPIController : ControllerBase
    {
        QltvApiContext db = new QltvApiContext();
        [HttpGet("{keyword1}")]
        public List<Sach> GetSachListTen(string keyword1)
        {
            var sach = db.Saches.Where(tl => tl.TenSach.Contains(keyword1)).ToList();
            return sach;
        }
        [HttpPut]
        public bool SuaTheoTheLoai(string MaSach, string TenSach, string TenTacGia, int SoLuong, int NamXuatBan, string MoTa, int GiaBia,
            string AnhDaiDien, string TinhTrangSach, string MaViTri, string MaTheLoai, string MaNxb)
        {
            var sach = db.Saches.FirstOrDefault(x => x.MaSach == MaSach);
            sach.TenSach = TenSach;
            sach.TenTacGia = TenTacGia;
            sach.SoLuong = SoLuong;
            sach.NamXuatBan = NamXuatBan;
            sach.MoTa = MoTa;
            sach.GiaBia = GiaBia;
            sach.AnhDaiDien = AnhDaiDien;
            sach.TinhTrangSach = TinhTrangSach;
            sach.MaViTri = MaViTri;
            sach.MaTheLoai = MaTheLoai;
            sach.MaNxb = MaNxb;
            db.Saches.Update(sach);
            db.SaveChanges();
            return true;
        }
        [HttpDelete]
        public bool DeleteSach(string MaSach)
        {
            try
            {
                Sach sach = db.Saches.FirstOrDefault(x => x.MaSach == MaSach);
                if (sach == null) return false;
                db.Saches.Remove(sach);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
