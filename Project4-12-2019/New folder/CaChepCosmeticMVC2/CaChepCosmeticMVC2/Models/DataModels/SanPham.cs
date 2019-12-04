using System;
using System.Collections.Generic;
using System.Linq;
using CaChepCosmeticMVC2.Data;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
        }

        public int SanPhamId { get; set; }
        public string TenSanPham { get; set; }
      
        
        public  string? Hinh { get; set; }
        public decimal GiaBan { get; set; }
        public int? ThuongHieuId { get; set; }
        public int? LoaiSanPhamId { get; set; }

    //    public int CongDungId { get; set; }
        public string? MoTa { get; set; }

      //  public virtual CongDung CongDung { get; set; }
        public virtual ThuongHieu ThuongHieu { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }


       
    }
}
