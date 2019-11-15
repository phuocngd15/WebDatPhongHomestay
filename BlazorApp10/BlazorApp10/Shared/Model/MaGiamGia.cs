using System;
using System.Collections.Generic;

namespace BlazorApp10.Shared.Model
{
    public  class MaGiamGia
    {
        public MaGiamGia()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public string MaGiamGia1 { get; set; }
        public string TenChuongTrinh { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string DieuKienApDung { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
