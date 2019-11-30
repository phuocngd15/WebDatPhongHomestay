using System;
using System.Collections.Generic;

namespace BlazorApp10.Shared.Model
{
    public  class ChiTieu
    {
        public int ChiTieuId { get; set; }
        public string Ten { get; set; }
        public decimal SoTien { get; set; }
        public DateTime ThoiGian { get; set; }
    }
}
