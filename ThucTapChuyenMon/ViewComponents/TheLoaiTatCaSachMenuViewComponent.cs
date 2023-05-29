using ThucTapChuyenMon.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenMon.ViewComponents
{
	public class TheLoaiTatCaSachMenuViewComponent :ViewComponent
	{
		private readonly ITheLoaiSachRepository _ISach;
		public TheLoaiTatCaSachMenuViewComponent(ITheLoaiSachRepository ISach)
		{
			_ISach = ISach;
		}
		public IViewComponentResult Invoke()
		{
			var Sach = _ISach.GetAllTheLoai().OrderBy(x => x.TenTheLoai);
			return View(Sach);
		}
	}
}
