using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class HoaDonMua
{
    public int SoHdmua { get; set; }

    public string MaNv { get; set; } = null!;

    public string MaKh { get; set; } = null!;

    public DateTime? NgayMua { get; set; }

    public double? MucGiamGia { get; set; }

    public virtual ICollection<ChiTietDonMua> ChiTietDonMuas { get; set; } = new List<ChiTietDonMua>();

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
