using System;
using System.Collections.Generic;

namespace BlazorApp10.Shared.Model
{
    public  class NhomCongDung
    {
        public NhomCongDung()
        {
            CongDung = new HashSet<CongDung>();
        }

        public int NhomCongDungId { get; set; }
        public string TenNhomCongDung { get; set; }

        public virtual ICollection<CongDung> CongDung { get; set; }
    }
}
