using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public string TenSach { get; set; } = null!;

    public int MaLoai { get; set; }

    public int? MaTacGia { get; set; }

    public int? MaNxb { get; set; }

    public int? NamXuatBan { get; set; }

    public decimal GiaBan { get; set; }

    public int SoLuongTon { get; set; }

    public string? MoTa { get; set; }

    public string? HinhAnh { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

    public virtual LoaiSach MaLoaiNavigation { get; set; } = null!;

    public virtual NhaXuatBan? MaNxbNavigation { get; set; }

    public virtual TacGium? MaTacGiaNavigation { get; set; }
}
