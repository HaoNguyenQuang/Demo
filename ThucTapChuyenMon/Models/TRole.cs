using System;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Models;

public partial class TRole
{
    public string MaRole { get; set; } = null!;

    public string TenRole { get; set; } = null!;

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
