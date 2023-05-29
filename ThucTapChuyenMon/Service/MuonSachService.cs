using ThucTapChuyenMon.Models;
using ThucTapChuyenMon.Models.MuonSachAPI;
using System;

namespace ThucTapChuyenMon.Service
{
    public class MuonSachService : IMuonSachService
    {
        QltvApiContext db  = new QltvApiContext();
        public async Task AddToCart(ChiTiet_MuonSach chiTiet_MuonSach)
        {
            var muonSach = new PhieuMuon
            {
                MaPhieuMuon = chiTiet_MuonSach.MaPhieuMuon,
                NgayMuon= DateTime.Now,
                NgayTra = DateTime.Now.AddDays(7),
                TinhTrangPhieuMuon = chiTiet_MuonSach.TinhTrangPhieuMuon,
                TongSachMuon = chiTiet_MuonSach.TongSachMuon,
                MaDocGia = chiTiet_MuonSach.MaDocGia,
                MaNhanVien = chiTiet_MuonSach.MaNhanVien,
            };
            var chiTietMuon = new ChiTietPhieuMuon
            {
                MaPhieuMuon = chiTiet_MuonSach.MaPhieuMuon,
                MaSach = chiTiet_MuonSach.MaSach,
                SoLuong = chiTiet_MuonSach.SoLuong
            };
            await db.PhieuMuons.AddAsync(muonSach);
            await db.ChiTietPhieuMuons.AddAsync(chiTietMuon);
            await db.SaveChangesAsync();
        }

        public async Task AddToCartExsits(ChiTietMuonSachDTO chiTietMuonSachDTO)
        {
            var chiTietMuon = new ChiTietPhieuMuon
            {
                MaPhieuMuon = chiTietMuonSachDTO.MaPhieuMuon,
                MaSach = chiTietMuonSachDTO.MaSach,
                SoLuong = chiTietMuonSachDTO.SoLuong
            };
            await db.ChiTietPhieuMuons.AddAsync(chiTietMuon);
            await db.SaveChangesAsync();
        }
    }
}
