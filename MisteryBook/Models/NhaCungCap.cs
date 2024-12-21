using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class NhaCungCap
{
    public int MaNcc { get; set; }

    public string TenNcc { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<DonNhap> DonNhaps { get; set; } = new List<DonNhap>();
}
