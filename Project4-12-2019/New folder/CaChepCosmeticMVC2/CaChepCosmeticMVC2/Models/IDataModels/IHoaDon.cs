using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Models.DataModels;

namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface IHoaDon
    {
        IEnumerable<HoaDon> GetAll();
        HoaDon GetOneById(int? id);
        void New(HoaDon a);
        void Edit(HoaDon a);
        void Delete(int id);
    }
}
