using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public DateOnly? NgayDangKy { get; set; }

    public virtual ICollection<DonHang> DonHangMaKhNavigations { get; set; } = new List<DonHang>();

    public virtual ICollection<DonHang> DonHangMaNvNavigations { get; set; } = new List<DonHang>();
}
