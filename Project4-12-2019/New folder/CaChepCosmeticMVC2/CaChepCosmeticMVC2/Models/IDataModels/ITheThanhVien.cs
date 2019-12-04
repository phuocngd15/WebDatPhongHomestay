using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Models.DataModels;

namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface ITheThanhVien
    {
        IEnumerable<TheThanhVien> GetAll();
        TheThanhVien GetOneById(int? id);
        void New(TheThanhVien a);
        void Edit(TheThanhVien a);
        void Delete(int id);
    }
}
