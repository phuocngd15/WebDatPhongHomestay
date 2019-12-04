using System;
using System.Collections.Generic;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public partial class CapBacThe
    {
        public CapBacThe()
        {
            TheThanhVien = new HashSet<TheThanhVien>();
        }

        public int CapBacTheId { get; set; }
        public string TenCapBac { get; set; }
        public decimal TienToiThieu { get; set; }
        public string QuyenLoi { get; set; }

        public virtual ICollection<TheThanhVien> TheThanhVien { get; set; }
    }
}
