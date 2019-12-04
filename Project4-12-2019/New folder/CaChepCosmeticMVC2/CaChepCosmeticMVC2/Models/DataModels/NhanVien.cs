using System;
using System.Collections.Generic;
using CaChepCosmeticMVC2.Service;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public class NhanVien
    {
        public int NhanVienId { get; set; }
        public string TenNv { get; set; }
        public string Sdt { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Cmnd { get; set; }
        public decimal? Luong { get; set; }
        public DateTime? NgayLam { get; set; }

        public int? AccoutId { get; set; }

        public virtual Account AccountBan { get; set; }

    }
}
