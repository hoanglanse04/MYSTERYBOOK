using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class DonHang
{
    public int SoDonHang { get; set; }

    public int MaKh { get; set; }

    public int? MaNv { get; set; }

    public DateOnly? NgayLap { get; set; }

    public int? TongSoLuong { get; set; }

    public decimal? TongTien { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual User MaKhNavigation { get; set; } = null!;

    public virtual User? MaNvNavigation { get; set; }
}
