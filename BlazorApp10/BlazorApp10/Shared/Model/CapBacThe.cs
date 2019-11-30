using System;
using System.Collections.Generic;

namespace BlazorApp10.Shared.Model
{
    public  class CapBacThe
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
