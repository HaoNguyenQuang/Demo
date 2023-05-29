using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class ChiTietPhieuMuon
{
    public string MaPhieuMuon { get; set; } = null!;

    public string MaSach { get; set; } = null!;

    public int SoLuong { get; set; }

    public virtual PhieuMuon MaPhieuMuonNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
