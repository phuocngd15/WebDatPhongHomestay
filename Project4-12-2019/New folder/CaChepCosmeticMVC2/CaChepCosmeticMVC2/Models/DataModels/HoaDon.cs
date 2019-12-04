using System;
using System.Collections.Generic;
using CaChepCosmeticMVC2.Service;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
        }

        public int HoaDonId { get; set; }
        public int? AccoutId { get; set; }
        public DateTime NgayLap { get; set; }
        public string? MaGiamGiaId { get; set; }
        public int? TheTvienId { get; set; }
        public decimal TongTien { get; set; }

        public virtual Account AccountBan { get; set; }

        public virtual MaGiamGia MaGiamGiaNavigation { get; set; }
        public virtual TheThanhVien TheTvien { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }
    }
}
