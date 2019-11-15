using System;
using System.Collections.Generic;

namespace BlazorApp10.Shared.Model
{
    public  class SanPham
    {
        public SanPham()
        {
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
        }

        public int SanPhamId { get; set; }
        public string TenSanPham { get; set; }
        public int? SoLuong { get; set; }
        public string Dvt { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int MaKe { get; set; }
        public int? ThuongHieuId { get; set; }
        public int CongDungId { get; set; }
        public string MoTa { get; set; }

        public virtual CongDung CongDung { get; set; }
        public virtual ThuongHieu ThuongHieu { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }
    }
}
