using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public partial class TheThanhVien
    {
        public TheThanhVien()
        {
            HoaDon = new HashSet<HoaDon>();
        }
        [Key]
        public int TheTvienId { get; set; }
        public decimal TongChiTieu { get; set; }
        public DateTime? Ngaylap { get; set; }
        public int CapbacTheId { get; set; }

        public virtual CapBacThe CapbacThe { get; set; }
        public virtual ICollection<HoaDon> HoaDon { get; set; }

        public  int? KhachHangId { get; set; }
        public KhachHang KhachHang { get; set; }
    }
}
