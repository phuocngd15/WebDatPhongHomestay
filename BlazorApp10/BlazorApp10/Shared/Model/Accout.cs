using System;
using System.Collections.Generic;

namespace BlazorApp10.Shared.Model
{
    public  class Accout
    {
        public Accout()
        {
            HoaDon = new HashSet<HoaDon>();
            NhanVien = new HashSet<NhanVien>();
        }

        public int AccoutId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Quyen { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }
        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}
