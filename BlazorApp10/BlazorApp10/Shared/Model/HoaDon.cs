using System;
using System.Collections.Generic;

namespace BlazorApp10.Shared.Model
{
    public  class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
        }

        public int HoaDonId { get; set; }
        public int AccoutId { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaGiamGia { get; set; }
        public int? TheTvienId { get; set; }
        public decimal TongTien { get; set; }

        public virtual Accout Accout { get; set; }
        public virtual MaGiamGia MaGiamGiaNavigation { get; set; }
        public virtual TheThanhVien TheTvien { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }
    }
}
