using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Models.DataModels;

namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface IKhachHang
    {
        IEnumerable<KhachHang> GetAll();
        KhachHang GetOneById(int? id);
        void New(KhachHang a);
        void Edit(KhachHang a);
        void Delete(int id);
    }
}
