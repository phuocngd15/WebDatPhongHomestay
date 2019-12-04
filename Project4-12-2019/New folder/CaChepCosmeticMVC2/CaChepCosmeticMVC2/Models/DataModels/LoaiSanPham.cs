using System.Collections.Generic;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public class LoaiSanPham
    {
        public LoaiSanPham()
        {
            SanPham = new HashSet<SanPham>();
        }
        public int LoaiSanPhamId { get; set; }
        public string TenLoaiSanPham { get; set; }
        public virtual ICollection<SanPham> SanPham { get; set; }

        public int? DanhMucSanPhamId { get; set; }
        public virtual DanhMucSanPham DanhMucSanPham { get; set; }

    }
}