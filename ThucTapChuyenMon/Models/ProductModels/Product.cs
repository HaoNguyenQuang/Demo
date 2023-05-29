namespace ThucTapChuyenMon.Models.ProductModels
{
	public class Product
	{
		public string MaSach { get; set; } = null!;

		public string TenSach { get; set; } = null!;

		public string TenTacGia { get; set; } = null!;

		public int SoLuong { get; set; }

		public int NamXuatBan { get; set; }

		public string MoTa { get; set; } = null!;

		public double GiaBia { get; set; }

		public string AnhDaiDien { get; set; } = null!;

		public string TinhTrangSach { get; set; } = null!;

		public string MaViTri { get; set; } = null!;

		public string MaTheLoai { get; set; } = null!;

		public string MaNxb { get; set; } = null!;
	}
}
