using System;
using System.Collections.Generic;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public partial class MaGiamGia
    {
        public MaGiamGia()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public string MaGiamGiaId { get; set; }
        public string TenChuongTrinh { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string DieuKienApDung { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
