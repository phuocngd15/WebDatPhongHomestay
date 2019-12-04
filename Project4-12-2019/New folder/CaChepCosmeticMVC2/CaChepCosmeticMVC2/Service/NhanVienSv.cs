using System;
using System.Collections.Generic;
using System.Linq;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public  class NhanVienSv
    {
        private readonly ApplicationDbContext _context;
        public NhanVienSv(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<NhanVien> GetAll()
        {
           return _context.NhanViens.FromSqlRaw("EXECUTE dbo.GetAllSanPham").ToList();

        }
    }
}
