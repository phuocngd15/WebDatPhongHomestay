using System;
using System.Collections.Generic;

namespace BlazorApp10.Shared.Model
{
    public  class ThuongHieu
    {
        public ThuongHieu()
        {
            SanPham = new HashSet<SanPham>();
        }

        public int ThuongHieuId { get; set; }
        public string TenThuongHieu { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
