using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class HoaDonNhap
{
    public int SoHdnh { get; set; }

    public DateTime? NgayNhap { get; set; }

    public string MaNxb { get; set; } = null!;

    public string MaNv { get; set; } = null!;

    public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

    public virtual NhanVien MaNvNavigation { get; set; } = null!;

    public virtual NhaXuatBan MaNxbNavigation { get; set; } = null!;
}
