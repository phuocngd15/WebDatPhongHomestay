using System;
using System.Collections.Generic;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public partial class ChiTietHoaDon
    {
        public int HoaDonId { get; set; }
        public int SanPhamId { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaBan { get; set; }
        public decimal ThanhTien { get; set; }

        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
