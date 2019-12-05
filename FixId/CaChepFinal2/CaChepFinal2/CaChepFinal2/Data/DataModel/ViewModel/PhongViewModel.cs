using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaChepFinal2.Data.DataModel.ViewModel
{
    public class PhongViewModel
    {
        public Phong phongs { get; set; }
        public IEnumerable<LoaiPhong> loaiphongs {get;set;}
    }
}
