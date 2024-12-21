using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class TacGium
{
    public int MaTacGia { get; set; }

    public string TenTacGia { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? QueQuan { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
