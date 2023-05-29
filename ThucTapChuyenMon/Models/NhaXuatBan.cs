using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class NhaXuatBan
{
    public string MaNxb { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string TenNxb { get; set; } = null!;

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
