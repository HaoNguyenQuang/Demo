using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class PhieuTra
{
    public string MaPhieuTra { get; set; } = null!;

    public string MaPhieuMuon { get; set; } = null!;

    public DateTime NgayTra { get; set; }

    public int TongSachTra { get; set; }

    public double TienPhat { get; set; }

    public virtual ICollection<ChiTietPhieuTra> ChiTietPhieuTras { get; set; } = new List<ChiTietPhieuTra>();
}
