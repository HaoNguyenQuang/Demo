using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class TheLoai
{
    public string MaTheLoai { get; set; } = null!;

    public string TenTheLoai { get; set; } = null!;

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
