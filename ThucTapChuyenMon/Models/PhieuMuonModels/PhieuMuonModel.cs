namespace ThucTapChuyenMon.Models.PhieuMuonModels
{
    public class PhieuMuonModel
    {
        public string MaPhieuMuon { get; set; } = null!;

        public DateTime NgayMuon { get; set; }

        public DateTime NgayTra { get; set; }

        public string MaNhanVien { get; set; } = null!;

        public string HoTen { get; set; } = null!;
        public string TenDocGia { get; set; } = null!;

        public string TinhTrangPhieuMuon { get; set; } = null!;
        public int TongSachMuon { get; set; }

    }
}
