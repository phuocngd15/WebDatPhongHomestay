using System;
using System.Collections.Generic;
using System.Linq;
using CaChepCosmeticMVC2.Data;
using CaChepCosmeticMVC2.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CaChepCosmeticMVC2.Service
{
    public  class TheThanhVienSv
    {
        private readonly ApplicationDbContext _context;
        public TheThanhVienSv(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TheThanhVien> GetAll()
        {
            return _context.TheThanhViens.FromSqlRaw("EXECUTE dbo.GetAllTheThanhVien").ToList();

        }
    }
}
