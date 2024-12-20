using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string? TenNv { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public DateTime? NgaySinh { get; set; }

    public DateTime? NgayVaoLam { get; set; }

    public string? GioiTinh { get; set; }

    public double? Luong { get; set; }

    public virtual ICollection<HoaDonMua> HoaDonMuas { get; set; } = new List<HoaDonMua>();

    public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; } = new List<HoaDonNhap>();
}
