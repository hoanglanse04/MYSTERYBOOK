using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class NhaXuatBan
{
    public int MaNxb { get; set; }

    public string TenNxb { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
