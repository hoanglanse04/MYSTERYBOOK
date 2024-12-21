﻿using System;
using System.Collections.Generic;

namespace MisteryBook.Models;

public partial class ChiTietDonNhap
{
    public int MaSach { get; set; }

    public int SoDonNhap { get; set; }

    public int SoLuong { get; set; }

    public decimal GiaNhap { get; set; }

    public virtual Sach MaSachNavigation { get; set; } = null!;

    public virtual DonNhap SoDonNhapNavigation { get; set; } = null!;
}