using ThucTapChuyenMon.Models;
using ThucTapChuyenMon.Models.ProductModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenMon.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SachAPI1Controller : ControllerBase
	{
		QltvApiContext db = new QltvApiContext();
		[HttpGet]
		public IEnumerable<Product> GetSach() 
		{
			var sach = (from p in db.Saches
						select new Product
						{
							MaSach = p.MaSach,
							TenSach = p.TenSach,
							TenTacGia = p.TenTacGia,
							SoLuong = p.SoLuong,
							NamXuatBan = p.NamXuatBan,
							MoTa = p.MoTa,
							GiaBia = p.GiaBia,
							AnhDaiDien = p.AnhDaiDien,
							TinhTrangSach = p.TinhTrangSach,
							MaViTri = p.MaViTri,
							MaTheLoai = p.MaTheLoai,
							MaNxb = p.MaNxb
						}).ToList();
			return sach;
		}
		[HttpGet("{matheloai}")]
		public IEnumerable<Product> GetProductByCategory(string MaTheLoai)
		{
			var sach = (from p in db.Saches
						where p.MaTheLoai == MaTheLoai
						select new Product
						{
							MaSach = p.MaSach,
							TenSach = p.TenSach,
							TenTacGia = p.TenTacGia,
							SoLuong = p.SoLuong,
							NamXuatBan = p.NamXuatBan,
							MoTa = p.MoTa,
							GiaBia = p.GiaBia,
							AnhDaiDien = p.AnhDaiDien,
							TinhTrangSach = p.TinhTrangSach,
							MaViTri = p.MaViTri,
							MaTheLoai = p.MaTheLoai,
							MaNxb = p.MaNxb
						}).ToList();
			return sach;
		}

	}
}
