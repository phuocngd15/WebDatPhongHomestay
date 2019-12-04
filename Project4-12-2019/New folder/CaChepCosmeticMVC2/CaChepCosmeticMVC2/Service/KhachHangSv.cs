using System;
using System.Collections.Generic;
using System.Linq;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using CaChepCosmeticMVC2.Models.IDataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public  class KhachHangSv : IKhachHang
    {
        private readonly ApplicationDbContext _context;
        public KhachHangSv(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(KhachHang a)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KhachHang> GetAll()
        {
            throw new NotImplementedException();
        }

        public KhachHang GetOneById(int? id)
        {
            throw new NotImplementedException();
        }

        public void New(KhachHang a)
        {
            throw new NotImplementedException();
        }
    }
}
