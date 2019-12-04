using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Models.DataModels;

namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface IMaGiamGia
    {
        IEnumerable<MaGiamGia> GetAll();
        MaGiamGia GetOneById(int? id);
        void New(MaGiamGia a);
        void Edit(MaGiamGia a);
        void Delete(int id);
    }
}
