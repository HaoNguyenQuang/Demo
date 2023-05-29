using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class Sach
{
    public string MaSach { get; set; } = null!;

    public string TenSach { get; set; } = null!;

    public string TenTacGia { get; set; } = null!;

    public int SoLuong { get; set; }

    public int NamXuatBan { get; set; }

    public string MoTa { get; set; } = null!;

    public double GiaBia { get; set; }

    public string AnhDaiDien { get; set; } = null!;

    public string TinhTrangSach { get; set; } = null!;

    public string MaViTri { get; set; } = null!;

    public string MaTheLoai { get; set; } = null!;

    public string MaNxb { get; set; } = null!;

    public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; } = new List<ChiTietPhieuMuon>();

    public virtual ICollection<ChiTietPhieuTra> ChiTietPhieuTras { get; set; } = new List<ChiTietPhieuTra>();

    public virtual NhaXuatBan MaNxbNavigation { get; set; } = null!;

    public virtual TheLoai MaTheLoaiNavigation { get; set; } = null!;

    public virtual ViTri MaViTriNavigation { get; set; } = null!;
}
