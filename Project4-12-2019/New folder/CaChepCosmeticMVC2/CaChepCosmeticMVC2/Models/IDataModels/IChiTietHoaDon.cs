using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Models.DataModels;

namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface IChiTietHoaDon
    {
        IEnumerable<ChiTietHoaDon> GetAll();
        ChiTietHoaDon GetOneById(int? id);
        void New(ChiTietHoaDon a);
        void Edit(ChiTietHoaDon a);
        void Delete(int id);
    }
}
