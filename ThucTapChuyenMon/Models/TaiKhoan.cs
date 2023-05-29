using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class TaiKhoan
{
    public string TaiKhoan1 { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MaRole { get; set; } = null!;

    public virtual ICollection<DocGia> DocGia { get; set; } = new List<DocGia>();

    public virtual TRole MaRoleNavigation { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
