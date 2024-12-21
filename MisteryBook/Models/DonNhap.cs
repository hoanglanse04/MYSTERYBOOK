using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class DonNhap
{
    public int SoDonNhap { get; set; }

    public int MaNcc { get; set; }

    public DateOnly? NgayNhap { get; set; }

    public int? TongSoLuong { get; set; }

    public decimal? TongTien { get; set; }

    public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

    public virtual NhaCungCap MaNccNavigation { get; set; } = null!;
}
