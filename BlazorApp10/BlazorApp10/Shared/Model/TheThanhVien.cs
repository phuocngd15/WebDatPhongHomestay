using System;
using System.Collections.Generic;

namespace BlazorApp10.Shared.Model
{
    public  class TheThanhVien
    {
        public TheThanhVien()
        {
            HoaDon = new HashSet<HoaDon>();
            KhachHang = new HashSet<KhachHang>();
        }

        public int TheTvienId { get; set; }
        public decimal TongChiTieu { get; set; }
        public DateTime? Ngaylap { get; set; }
        public int CapbacTheId { get; set; }

        public virtual CapBacThe CapbacThe { get; set; }
        public virtual ICollection<HoaDon> HoaDon { get; set; }
        public virtual ICollection<KhachHang> KhachHang { get; set; }
    }
}
