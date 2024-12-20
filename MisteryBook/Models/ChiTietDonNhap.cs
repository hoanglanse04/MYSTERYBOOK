using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class ChiTietDonNhap
{
    public int SoHdnh { get; set; }

    public string MaSach { get; set; } = null!;

    public int? SoLuongNhap { get; set; }

    public double? GiaNhap { get; set; }

    public virtual Sach MaSachNavigation { get; set; } = null!;

    public virtual HoaDonNhap SoHdnhNavigation { get; set; } = null!;
}
