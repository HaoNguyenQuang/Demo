using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class ChiTietPhieuTra
{
    public string MaPhieuTra { get; set; } = null!;

    public string MaSach { get; set; } = null!;

    public int SoLuong { get; set; }

    public string NhaXuatBan { get; set; } = null!;

    public string TenSach { get; set; } = null!;

    public string TinhTrangSach { get; set; } = null!;

    public virtual PhieuTra MaPhieuTraNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
