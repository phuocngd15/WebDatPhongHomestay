using System;
using System.Collections.Generic;

namespace BlazorApp10.Shared.Model
{
    public  class CongDung
    {
        public CongDung()
        {
            SanPham = new HashSet<SanPham>();
        }

        public int CongDungId { get; set; }
        public string TenCongDung { get; set; }
        public int NhomCongDungId { get; set; }

        public virtual NhomCongDung NhomCongDung { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
