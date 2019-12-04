using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Models.DataModels;

namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface INhanVien
    {
        IEnumerable<NhanVien> GetAll();
        NhanVien GetOneById(int? id);
        void New(NhanVien a);
        void Edit(NhanVien a);
        void Delete(int id);
    }
}
