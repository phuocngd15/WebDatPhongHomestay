using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Models.DataModels;

namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface IChiTieu
    {
        IEnumerable<ChiTieu> GetAll();
        ChiTieu GetOneById(int? id);
        void New(ChiTieu a);
        void Edit(ChiTieu a);
        void Delete(int id);
    }
}
