using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string GioiTinh { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public int SoDienThoai { get; set; }

    public DateTime NgaySinh { get; set; }

    public string Email { get; set; } = null!;

    public string TaiKhoan { get; set; } = null!;

    public virtual ICollection<PhieuMuon> PhieuMuons { get; set; } = new List<PhieuMuon>();

    public virtual TaiKhoan TaiKhoanNavigation { get; set; } = null!;
}
