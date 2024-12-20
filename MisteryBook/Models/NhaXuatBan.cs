using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class NhaXuatBan
{
    public string MaNxb { get; set; } = null!;

    public string? TenNxb { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; } = new List<HoaDonNhap>();

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
