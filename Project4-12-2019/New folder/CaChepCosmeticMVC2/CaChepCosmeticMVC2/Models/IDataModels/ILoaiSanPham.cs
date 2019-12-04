using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Models.DataModels;

namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface ILoaiSanPham
    {
        IEnumerable<LoaiSanPham> GetAll();
        LoaiSanPham GetOneById(int? id);
        void New(LoaiSanPham a);
        void Edit(LoaiSanPham a);
        void Delete(int id);
    }
}
