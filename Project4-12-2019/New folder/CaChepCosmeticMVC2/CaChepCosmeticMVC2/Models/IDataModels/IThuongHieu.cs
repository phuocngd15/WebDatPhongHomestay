using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Models.DataModels;

namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface IThuongHieu
    {
        IEnumerable<ThuongHieu> GetAll();
        ThuongHieu GetOneById(int? id);
        void New(ThuongHieu a);
        void Edit(ThuongHieu a);
        void Delete(int id);
    }
}
