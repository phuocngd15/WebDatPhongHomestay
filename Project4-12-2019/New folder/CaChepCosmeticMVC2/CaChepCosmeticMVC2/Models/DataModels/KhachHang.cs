﻿using System;
using System.Collections.Generic;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public partial class KhachHang
    {
        public int KhachHangId { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime NgaySinh { get; set; }
        public int Sdt { get; set; }
        public string Email { get; set; }
        public virtual TheThanhVien TheTvien { get; set; }
    }
}
