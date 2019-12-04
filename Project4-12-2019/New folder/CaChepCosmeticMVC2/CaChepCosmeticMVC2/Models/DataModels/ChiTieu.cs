using System;
using System.Collections.Generic;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public partial class ChiTieu
    {
        public int ChiTieuId { get; set; }
        public string Ten { get; set; }
        public decimal SoTien { get; set; }
        public DateTime ThoiGian { get; set; }
    }
}
