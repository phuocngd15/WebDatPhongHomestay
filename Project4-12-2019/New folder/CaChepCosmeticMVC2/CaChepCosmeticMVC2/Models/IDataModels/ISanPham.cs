using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Models.DataModels;

namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface ISanPham
    {
        IEnumerable<SanPham> GetAll();
        SanPham GetOneById(int? id);
        void New(SanPham a);
        void Edit(SanPham a);
        void Delete(int id);
    }
}
