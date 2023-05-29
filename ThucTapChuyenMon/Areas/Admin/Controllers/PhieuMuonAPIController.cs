using ThucTapChuyenMon.Models.PhieuMuonModels;
using ThucTapChuyenMon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenMon.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuMuonAPIController : ControllerBase
    {
        QltvApiContext db = new QltvApiContext();
        [HttpGet]
        public IEnumerable<PhieuMuonModel> GetPhieuMuon(string tinhtrangphieumuon)
        {
            var phieumuon = (from p in db.PhieuMuons
                        join d in db.NhanViens on p.MaNhanVien equals d.MaNhanVien
                        join b in db.DocGia on p.MaDocGia equals b.MaDocGia
                        where p.TinhTrangPhieuMuon != tinhtrangphieumuon
                             select new PhieuMuonModel
                        {
                            MaPhieuMuon = p.MaPhieuMuon,
                            NgayMuon = p.NgayMuon,
                            NgayTra = p.NgayTra,
                            MaNhanVien = p.MaNhanVien,
                            HoTen = d.HoTen,
                            TenDocGia = b.TenDocGia,
                            TinhTrangPhieuMuon = p.TinhTrangPhieuMuon,
                            TongSachMuon = p.TongSachMuon
                        }).ToList();
            return phieumuon;
        }

    }
}
