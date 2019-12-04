using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaChepFinal2.Data.DataModel.ViewModel
{
    public class DichVuViewModel
    {
        public DichVu dichvus { get; set; }
        public IEnumerable<LoaiDichVu> loaidichvus { get; set; }
    }
}
