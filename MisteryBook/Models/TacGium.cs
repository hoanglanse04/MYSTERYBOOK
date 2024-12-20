using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class TacGium
{
    public string MaTg { get; set; } = null!;

    public string? TenTg { get; set; }

    public virtual ICollection<Sach> MaSaches { get; set; } = new List<Sach>();
}
