namespace ThucTapChuyenMon.Models.MuonSachAPI
{
    public class ChiTiet_MuonSach
    {
        public string MaPhieuMuon { get; set; } 

        public DateTime NgayMuon { get; set; }

        public DateTime NgayTra { get; set; }

        public string TinhTrangPhieuMuon { get; set; } 

        public int TongSachMuon { get; set; }

        public string MaDocGia { get; set; } 

        public string MaNhanVien { get; set; } 
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
    }
}
