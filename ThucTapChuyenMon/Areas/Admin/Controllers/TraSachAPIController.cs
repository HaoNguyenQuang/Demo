using ThucTapChuyenMon.Models;
using ThucTapChuyenMon.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenMon.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraSachAPIController : ControllerBase
    {
        private readonly IMuonSachService _muonSachService;
        QltvApiContext db = new QltvApiContext();
        public TraSachAPIController(IMuonSachService gioHangService, QltvApiContext db)
        {
            _muonSachService = gioHangService;
            this.db = db;
        }
        [HttpPut]
        public bool SuaPhieuMuon(string MaPhieuMuon, DateTime NgayMuon, DateTime NgayTra, string TinhTrang, int TongSachMuon, string MaDocGia, string MaNhanVien,
            DateTime NgayTraThucTe, float TienPhat, string GhiChu)
        {
            var phieumuon = db.PhieuMuons.FirstOrDefault(x => x.MaPhieuMuon == MaPhieuMuon);
            phieumuon.NgayMuon = NgayMuon;
            phieumuon.NgayTra = NgayTra;
            phieumuon.TinhTrangPhieuMuon = TinhTrang;
            phieumuon.TongSachMuon = TongSachMuon;
            phieumuon.MaDocGia = MaDocGia;
            phieumuon.MaNhanVien = MaNhanVien;
            phieumuon.NgayTraThucTe = NgayTraThucTe;
            phieumuon.TienPhat = TienPhat;
            phieumuon.GhiChu = GhiChu;
            db.PhieuMuons.Update(phieumuon);
            db.SaveChanges();
            return true;
        }
        //Update trả sách
        [HttpPut("{maPhieuMuon}")]
        public async Task<IActionResult> updateTraSach(string maPhieuMuon)
        {
            var invoice = db.PhieuMuons.FirstOrDefault(x => x.MaPhieuMuon == maPhieuMuon);
            invoice.TinhTrangPhieuMuon = "Đã Trả";
            db.PhieuMuons.Update(invoice);
            await db.SaveChangesAsync();
            return Ok(123);
        }
    }
}
