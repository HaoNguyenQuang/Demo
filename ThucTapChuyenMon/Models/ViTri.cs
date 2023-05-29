using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class ViTri
{
    public string MaViTri { get; set; } = null!;

    public string KeSach { get; set; } = null!;

    public string NganSach { get; set; } = null!;

    public string GiaSach { get; set; } = null!;

    public int ViTriTrenGia { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
