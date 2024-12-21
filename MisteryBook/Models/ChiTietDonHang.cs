using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class ChiTietDonHang
{
    public int MaSach { get; set; }

    public int SoDonHang { get; set; }

    public int SoLuong { get; set; }

    public decimal GiaBan { get; set; }

    public virtual Sach MaSachNavigation { get; set; } = null!;

    public virtual DonHang SoDonHangNavigation { get; set; } = null!;
}
