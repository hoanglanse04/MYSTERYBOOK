using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class Sach
{
    public string MaSach { get; set; } = null!;

    public string? TenSach { get; set; }

    public string MaNxb { get; set; } = null!;

    public string? TheLoai { get; set; }

    public int? SoLuong { get; set; }

    public double? GiaBan { get; set; }

    public virtual ICollection<ChiTietDonMua> ChiTietDonMuas { get; set; } = new List<ChiTietDonMua>();

    public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

    public virtual NhaXuatBan MaNxbNavigation { get; set; } = null!;

    public virtual ICollection<TacGium> MaTgs { get; set; } = new List<TacGium>();
}
