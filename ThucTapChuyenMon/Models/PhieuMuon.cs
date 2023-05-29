using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class PhieuMuon
{
    public string MaPhieuMuon { get; set; } = null!;

    public DateTime NgayMuon { get; set; }

    public DateTime NgayTra { get; set; }

    public string TinhTrangPhieuMuon { get; set; } = null!;

    public int TongSachMuon { get; set; }

    public string MaDocGia { get; set; } = null!;

    public string MaNhanVien { get; set; } = null!;

    public DateTime? NgayTraThucTe { get; set; }

    public double? TienPhat { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; } = new List<ChiTietPhieuMuon>();

    public virtual DocGia MaDocGiaNavigation { get; set; } = null!;

    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;
}
