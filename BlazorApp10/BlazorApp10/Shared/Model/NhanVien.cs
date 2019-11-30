using System;
using System.Collections.Generic;

namespace BlazorApp10.Shared.Model
{
    public  class NhanVien
    {
        public int Idnv { get; set; }
        public string TenNv { get; set; }
        public int Sdt { get; set; }
        public DateTime NgaySinh { get; set; }
        public int Cmnd { get; set; }
        public decimal? Luong { get; set; }
        public DateTime? NgayLam { get; set; }
        public int? AccoutId { get; set; }

        public virtual Accout Accout { get; set; }
    }
}
