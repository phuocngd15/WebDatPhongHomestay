using System;
using System.Collections.Generic;
using System.Linq;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using CaChepCosmeticMVC2.Models.IDataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public  class MaGiamGiaSv : IMaGiamGia
    {
        private readonly ApplicationDbContext _context;
        public MaGiamGiaSv(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(MaGiamGia a)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MaGiamGia> GetAll()
        {
            throw new NotImplementedException();
        }

        public MaGiamGia GetOneById(int? id)
        {
            throw new NotImplementedException();
        }

        public void New(MaGiamGia a)
        {
            throw new NotImplementedException();
        }
    }
}
