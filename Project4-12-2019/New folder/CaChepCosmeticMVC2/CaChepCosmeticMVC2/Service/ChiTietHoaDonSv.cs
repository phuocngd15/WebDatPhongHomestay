using System;
using System.Collections.Generic;
using System.Linq;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using CaChepCosmeticMVC2.Models.IDataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public  class ChiTietHoaDonSv: IChiTietHoaDon
    {
        private readonly ApplicationDbContext _context;
        public ChiTietHoaDonSv(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ChiTietHoaDonSv> GetAll()
        {
            //   return _context.ch.FromSqlRaw("EXECUTE dbo.GetAllSanPham").ToList();
            throw new NotImplementedException();
        }

        public ChiTietHoaDon GetOneById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChiTietHoaDon> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void New(ChiTietHoaDon a)
        {
            throw new NotImplementedException();
        }

        public void Edit(ChiTietHoaDon a)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ChiTietHoaDon> IChiTietHoaDon.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
