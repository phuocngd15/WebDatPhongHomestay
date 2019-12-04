using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepCosmeticMVC2.Models.DataModels;

namespace CaChepCosmeticMVC2.Models.IDataModels
{
    public interface IThu
    {
        IEnumerable<Thu> GetAll();
        Thu GetOneById(int? id);
        void New(Thu a);
        void Edit(Thu a);
        void Delete(int id);
    }
}
