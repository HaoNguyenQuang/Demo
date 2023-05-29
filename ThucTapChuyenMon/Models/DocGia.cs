using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class DocGia
{
    public string MaDocGia { get; set; } = null!;

    public string TenDocGia { get; set; } = null!;

    public string GioiTinh { get; set; } = null!;

    public int SoDienThoai { get; set; }

    public string DiaChi { get; set; } = null!;

    public DateTime NgaySinh { get; set; }

    public string Email { get; set; } = null!;

    public string TaiKhoan { get; set; } = null!;

    public virtual ICollection<PhieuMuon> PhieuMuons { get; set; } = new List<PhieuMuon>();

    public virtual TaiKhoan TaiKhoanNavigation { get; set; } = null!;
}
