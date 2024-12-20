using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string? TenKh { get; set; }

    public string? Sdt { get; set; }

    public string? GioiTinh { get; set; }

    public DateTime? NgaySinh { get; set; }

    public virtual ICollection<HoaDonMua> HoaDonMuas { get; set; } = new List<HoaDonMua>();
}
