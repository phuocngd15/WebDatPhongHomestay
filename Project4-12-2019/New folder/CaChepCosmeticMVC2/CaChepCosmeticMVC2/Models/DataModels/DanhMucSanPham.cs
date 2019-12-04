using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public class DanhMucSanPham
    {
        public DanhMucSanPham()
        {
            LoaiSanPhams = new HashSet<LoaiSanPham>();
        }
        [Key]
        public int DanhMucSanPhamId { get; set; }

        [Display (Name = "Danh Mục Sản Phẩm")]
        public string TenDanhMucSanPham{ get; set; }
        public virtual ICollection<LoaiSanPham> LoaiSanPhams { get; set; }
    }
}
