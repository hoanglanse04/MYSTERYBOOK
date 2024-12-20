using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class ChiTietDonMua
{
    public int SoHdmua { get; set; }

    public string MaSach { get; set; } = null!;

    public double? DonGia { get; set; }

    public int? SoLuongMua { get; set; }

    public virtual Sach MaSachNavigation { get; set; } = null!;

    public virtual HoaDonMua SoHdmuaNavigation { get; set; } = null!;
}
