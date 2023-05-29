using ThucTapChuyenMon.Areas.Admin.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenMon.Areas.Admin.ViewComponents
{
    public class TheLoaiMenuViewComponent : ViewComponent
    {
        private readonly ITheLoaiSachRepository _ISach;
        public TheLoaiMenuViewComponent(ITheLoaiSachRepository ISach)
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
