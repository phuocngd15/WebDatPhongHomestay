using System;
using System.Collections.Generic;
using System.Linq;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using CaChepCosmeticMVC2.Models.IDataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public  class HoaDonSv:IHoaDon
    {
        private readonly ApplicationDbContext _context;
        public HoaDonSv(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(HoaDon a)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HoaDon> GetAll()
        {
            throw new NotImplementedException();
        }

        public HoaDon GetOneById(int? id)
        {
            throw new NotImplementedException();
        }

        public void New(HoaDon a)
        {
            throw new NotImplementedException();
        }
    }
}
